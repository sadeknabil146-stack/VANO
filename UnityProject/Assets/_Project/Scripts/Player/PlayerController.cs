using UnityEngine;

namespace Vano
{
    /// <summary>
    /// Core downhill movement controller. Uses Rigidbody physics with gravity, slope, steering,
    /// acceleration, drift, jump, slide and air control. Vehicle stats are applied from a VehicleData.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    public class PlayerController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerInput input;
        [SerializeField] private VehicleData vehicleData;

        [Header("Movement Tuning")]
        [SerializeField] private float maxSpeed = 28f;
        [SerializeField] private float acceleration = 14f;
        [SerializeField] private float steerTorque = 6f;
        [SerializeField] private float airSteerTorque = 2f;
        [SerializeField] private float jumpForce = 7f;
        [SerializeField] private float gravityMultiplier = 1.4f;
        [SerializeField] private float slopeBoost = 6f;
        [SerializeField] private float friction = 0.6f;
        [SerializeField] private float driftFriction = 0.25f;
        [SerializeField] private float slideSpeedMultiplier = 0.75f;

        [Header("State (read-only)")]
        [SerializeField] private bool isGrounded;
        [SerializeField] private bool isDrifting;
        [SerializeField] private bool isSliding;
        [SerializeField] private bool isAirborne;

        private Rigidbody rb;
        private CapsuleCollider col;
        private float colliderHeight;
        private Vector3 colliderCenter;
        private float slideTimer;
        private bool jumpQueued;

        // public read access for camera/UI
        public float Speed => rb != null ? rb.velocity.magnitude : 0f;
        public bool IsGrounded => isGrounded;
        public bool IsDrifting => isDrifting;
        public bool IsSliding => isSliding;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            col = GetComponent<CapsuleCollider>();
            colliderHeight = col.height;
            colliderCenter = col.center;
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }

        void Start()
        {
            if (vehicleData != null) ApplyVehicle(vehicleData);
            if (input == null) input = GetComponent<PlayerInput>();
            if (input == null) input = FindObjectOfType<PlayerInput>();
        }

        void Update()
        {
            if (input == null) return;
            if (input.JumpPressed && isGrounded) jumpQueued = true;
            if (input.SlideHeld) StartSlide();
            else StopSlide();
        }

        void FixedUpdate()
        {
            CheckGrounded();
            ApplyGravityAndSlope();
            ApplySteering();
            ApplyAcceleration();
            ApplyDrift();
            ApplyJump();
            ApplySlide();
            ClampSpeed();
        }

        private void CheckGrounded()
        {
            // sphere cast slightly below collider
            Vector3 origin = transform.position + Vector3.up * 0.1f;
            float radius = col.radius * 0.9f;
            isGrounded = Physics.SphereCast(origin, radius, Vector3.down, out _, 0.25f + 0.1f);
            isAirborne = !isGrounded;
        }

        private void ApplyGravityAndSlope()
        {
            // extra gravity for downhill feel
            rb.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);

            // slope boost: project velocity onto downhill direction
            if (isGrounded)
            {
                // raycast to get surface normal
                if (Physics.Raycast(transform.position + Vector3.up * 0.5f, Vector3.down, out RaycastHit hit, 2f))
                {
                    Vector3 slopeDir = Vector3.ProjectOnPlane(Vector3.down, hit.normal).normalized;
                    float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);
                    if (slopeAngle > 2f)
                    {
                        rb.AddForce(slopeDir * slopeBoost * Mathf.Sin(slopeAngle * Mathf.Deg2Rad), ForceMode.Acceleration);
                    }
                }
            }
        }

        private void ApplySteering()
        {
            float steer = input != null ? input.SteerAxis : 0f;
            float torque = isGrounded ? steerTorque : airSteerTorque;
            // turning radius shrinks with speed slightly
            float speedFactor = Mathf.Clamp01(rb.velocity.magnitude / maxSpeed);
            torque *= (1f - speedFactor * 0.3f);
            if (Mathf.Abs(steer) > 0.01f)
            {
                rb.AddTorque(Vector3.up * steer * torque, ForceMode.Acceleration);
            }
            // align forward velocity with facing direction (carving)
            if (isGrounded)
            {
                Vector3 fwd = transform.forward;
                Vector3 vel = rb.velocity;
                Vector3 lateral = Vector3.Project(vel, transform.right);
                // reduce lateral slip
                rb.velocity = vel - lateral * (isDrifting ? 0.3f : 0.8f);
            }
        }

        private void ApplyAcceleration()
        {
            if (!isGrounded) return;
            // forward acceleration along facing direction
            Vector3 forward = transform.forward;
            forward.y = 0f;
            if (forward.sqrMagnitude < 0.001f) return;
            forward.Normalize();
            float currentForwardSpeed = Vector3.Dot(rb.velocity, forward);
            if (currentForwardSpeed < maxSpeed)
            {
                rb.AddForce(forward * acceleration, ForceMode.Acceleration);
            }
        }

        private void ApplyDrift()
        {
            float steer = input != null ? input.SteerAxis : 0f;
            // drift when steering hard at speed
            bool wantDrift = isGrounded && Mathf.Abs(steer) > 0.6f && rb.velocity.magnitude > maxSpeed * 0.4f;
            isDrifting = wantDrift;
            // adjust friction
            float fric = isDrifting ? driftFriction : friction;
            if (isGrounded)
            {
                Vector3 vel = rb.velocity;
                Vector3 lateral = Vector3.Project(vel, transform.right);
                rb.velocity = vel - lateral * (1f - fric);
            }
        }

        private void ApplyJump()
        {
            if (jumpQueued)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                jumpQueued = false;
            }
        }

        private void StartSlide()
        {
            if (isSliding) return;
            isSliding = true;
            col.height = colliderHeight * 0.5f;
            col.center = colliderCenter * 0.5f;
        }

        private void StopSlide()
        {
            if (!isSliding) return;
            isSliding = false;
            col.height = colliderHeight;
            col.center = colliderCenter;
        }

        private void ApplySlide()
        {
            if (!isSliding) return;
            // reduce speed while sliding
            rb.velocity = new Vector3(rb.velocity.x * slideSpeedMultiplier, rb.velocity.y, rb.velocity.z * slideSpeedMultiplier);
        }

        private void ClampSpeed()
        {
            Vector3 v = rb.velocity;
            Vector3 horizontal = new Vector3(v.x, 0f, v.z);
            if (horizontal.magnitude > maxSpeed)
            {
                horizontal = horizontal.normalized * maxSpeed;
                rb.velocity = new Vector3(horizontal.x, v.y, horizontal.z);
            }
        }

        public void ApplyVehicle(VehicleData data)
        {
            if (data == null) return;
            maxSpeed = data.maxSpeed;
            acceleration = data.acceleration;
            steerTorque = data.steerTorque;
            jumpForce = data.jumpForce;
            friction = data.friction;
            driftFriction = data.driftFriction;
            slideSpeedMultiplier = data.slideSpeedMultiplier;
        }
    }
}
