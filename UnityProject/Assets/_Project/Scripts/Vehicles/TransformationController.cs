using UnityEngine;

namespace Vano
{
    /// <summary>
    /// Handles vehicle transformation via double-tap. Cycles through a list of VehicleData,
    /// applies stats to PlayerController, manages duration, cooldown and brief invulnerability.
    /// </summary>
    public class TransformationController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerController player;
        [SerializeField] private PlayerInput input;

        [Header("Vehicles")]
        [Tooltip("Index 0 should be the Standard Snowboard (default).")]
        [SerializeField] private VehicleData[] vehicles;

        [Header("Tuning")]
        [SerializeField] private float transitionTime = 0.4f;
        [SerializeField] private float invulnerabilityTime = 0.5f;

        private int currentIndex = 0;
        private float durationTimer;
        private float cooldownTimer;
        private float invulnTimer;
        private bool isTransforming;

        public int CurrentIndex => currentIndex;
        public bool IsInvulnerable => invulnTimer > 0f;
        public VehicleData CurrentVehicle => (vehicles != null && vehicles.Length > 0) ? vehicles[currentIndex] : null;

        void Start()
        {
            if (player == null) player = GetComponent<PlayerController>();
            if (input == null) input = GetComponent<PlayerInput>();
            if (vehicles != null && vehicles.Length > 0)
                player.ApplyVehicle(vehicles[0]);
        }

        void Update()
        {
            if (input == null) return;

            // timers
            if (cooldownTimer > 0f) cooldownTimer -= Time.deltaTime;
            if (invulnTimer > 0f) invulnTimer -= Time.deltaTime;
            if (durationTimer > 0f)
            {
                durationTimer -= Time.deltaTime;
                if (durationTimer <= 0f) RevertToStandard();
            }

            // transform trigger
            if (input.TransformPressed && cooldownTimer <= 0f && !isTransforming)
            {
                CycleVehicle();
            }
        }

        private void CycleVehicle()
        {
            if (vehicles == null || vehicles.Length < 2) return;
            isTransforming = true;
            currentIndex = (currentIndex + 1) % vehicles.Length;
            VehicleData v = vehicles[currentIndex];
            player.ApplyVehicle(v);
            durationTimer = v.duration;
            cooldownTimer = v.cooldown;
            invulnTimer = invulnerabilityTime;
            isTransforming = false;
            // TODO: play transition VFX / swap mesh here
        }

        private void RevertToStandard()
        {
            if (vehicles == null || vehicles.Length == 0) return;
            currentIndex = 0;
            player.ApplyVehicle(vehicles[0]);
            durationTimer = 0f;
        }
    }
}
EOF
echo done