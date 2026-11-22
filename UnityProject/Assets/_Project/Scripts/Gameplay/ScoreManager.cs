using UnityEngine;

namespace Vano
{
    /// <summary>
    /// Thin score tracker. Delegates to GameManager for a single source of truth.
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
        }

        public void AddScore(int amount)
        {
            if (GameManager.Instance != null) GameManager.Instance.AddScore(amount);
        }
    }
}
EOF
echo done