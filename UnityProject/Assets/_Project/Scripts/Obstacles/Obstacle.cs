using UnityEngine;

namespace Vano
{
    /// <summary>
    /// Obstacle. On collision with player triggers a crash (game over) unless invulnerable.
    /// </summary>
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private bool lethal = true;

        void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.CompareTag("Player")) return;
            if (lethal)
            {
                var t = collision.collider.GetComponent<TransformationController>();
                if (t != null && t.IsInvulnerable) return;
                GameManager.Instance?.Crash();
            }
        }
    }
}
EOF
echo done