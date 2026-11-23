using UnityEngine;
using UnityEngine.UI;

namespace Vano
{
    /// <summary>
    /// Minimal HUD: score, crystals, speed. Wire Text fields in Inspector.
    /// </summary>
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Text crystalsText;
        [SerializeField] private Text speedText;
        [SerializeField] private Text vehicleText;

        private PlayerController player;
        private TransformationController transformCtrl;

        void Start()
        {
            var p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
            {
                player = p.GetComponent<PlayerController>();
                transformCtrl = p.GetComponent<TransformationController>();
            }
        }

        void Update()
        {
            if (GameManager.Instance != null)
            {
                if (scoreText != null) scoreText.text = "Score: " + GameManager.Instance.Score;
                if (crystalsText != null) crystalsText.text = "Crystals: " + GameManager.Instance.Crystals;
            }
            if (player != null && speedText != null)
                speedText.text = "Speed: " + Mathf.RoundToInt(player.Speed);
            if (transformCtrl != null && vehicleText != null && transformCtrl.CurrentVehicle != null)
                vehicleText.text = transformCtrl.CurrentVehicle.vehicleName;
        }
    }
}
EOF
echo done