using UnityEngine;

namespace Vano
{
    /// <summary>
    /// Third-person follow camera with smooth damping, speed-based FOV and corner tilt.
    /// </summary>
    public class ThirdPersonCamera : MonoBehaviour
    {
        [Header("Target")]
        [SerializeField] private Transform target;
        [SerializeField] private PlayerController player;

        [Header("Position")]
        [SerializeField] private Vector3 offset = new Vector3(0f, 4f, -7f);
        [SerializeField] private float followSmooth = 8f;
        [SerializeField] private float rotateSmooth = 6f;

        [Header("FOV")]
        [SerializeField] private float baseFov = 60f;
        [SerializeField] private float maxFov = 72f;
        [SerializeField] private float fovSpeedScale = 0.4f;

        [Header("Tilt")]
        [SerializeField] private float maxTilt = 6f;

        private Camera cam;
        private Vector3 currentVelocity;

        void Start()
        {
            cam = GetComponent<Camera>();
            if (cam == null) cam = Camera.main;
            if (target == null && player != null) target = player.transform;
        }

        void LateUpdate()
        {
            if (target == null) return;

            // desired position behind target
            Vector3 desired = target.position + target.TransformDirection(offset);
            transform.position = Vector3.SmoothDamp(transform.position, desired, ref currentVelocity, 1f / followSmooth);

            // look at target
            Vector3 lookDir = target.position - transform.position;
            if (lookDir.sqrMagnitude > 0.001f)
            {
                Quaternion desiredRot = Quaternion.LookRotation(lookDir.normalized, Vector3.up);
                // add tilt based on steer input (approx via velocity cross)
                float steer = 0f;
                if (player != null)
                {
                    // tilt from horizontal velocity relative to forward
                    Vector3 vel = player.GetComponent<Rigidbody>().velocity;
                    Vector3 flatVel = new Vector3(vel.x, 0f, vel.z);
                    float side = Vector3.Dot(flatVel, target.right);
                    steer = Mathf.Clamp(side / 5f, -1f, 1f);
                }
                Quaternion tilt = Quaternion.Euler(0f, 0f, -steer * maxTilt);
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredRot * tilt, rotateSmooth * Time.deltaTime);
            }

            // speed-based FOV
            if (cam != null && player != null)
            {
                float speedNorm = Mathf.Clamp01(player.Speed / 30f);
                cam.fieldOfView = Mathf.Lerp(baseFov, maxFov, speedNorm * fovSpeedScale + speedNorm * 0.6f);
            }
        }
    }
}
