using UnityEngine;

namespace Vano
{
    /// <summary>
    /// Data-driven vehicle stats. Create instances via Assets > Create > Vano > Vehicle Data.
    /// </summary>
    [CreateAssetMenu(fileName = "VehicleData", menuName = "Vano/Vehicle Data")]
    public class VehicleData : ScriptableObject
    {
        public string vehicleName = "Standard Snowboard";
        public float maxSpeed = 28f;
        public float acceleration = 14f;
        public float steerTorque = 6f;
        public float jumpForce = 7f;
        public float friction = 0.6f;
        public float driftFriction = 0.25f;
        public float slideSpeedMultiplier = 0.75f;
        public float duration = 12f;
        public float cooldown = 2f;
    }
}