using UnityEngine;
using UnityEngine.SceneManagement;

namespace Vano
{
    /// <summary>
    /// Singleton game state manager. Tracks running/crashed, crystals, restart.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public bool IsRunning { get; private set; } = true;
        public int Crystals { get; private set; }
        public int Score { get; private set; }

        [Header("References")]
        [SerializeField] private GameObject player;

        void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
        }

        public void AddCrystals(int amount) { if (IsRunning) Crystals += amount; }
        public void AddScore(int amount) { if (IsRunning) Score += amount; }

        public void Crash()
        {
            if (!IsRunning) return;
            IsRunning = false;
            Time.timeScale = 0f;
            Debug.Log($"CRASH! Score={Score} Crystals={Crystals}");
            // TODO: show crash UI panel
        }

        public void Restart()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
