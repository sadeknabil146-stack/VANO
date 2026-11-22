using UnityEngine;

namespace Vano
{
    /// <summary>
    /// A collectible crystal. Rotates and bobs; collected on trigger.
    /// </summary>
    public class Crystal : MonoBehaviour
    {
        [SerializeField] private int value = 1;
        [SerializeField] private float rotateSpeed = 90f;
        [SerializeField] private float bobAmplitude = 0.25f;
        [SerializeField] private float bobSpeed = 2f;

        private Vector3 startPos;

        void Start() { startPos = transform.position; }

        void Update()
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
            float bob = Mathf.Sin(Time.time * bobSpeed) * bobAmplitude;
            transform.position = startPos + Vector3.up * bob;
        }

        void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            GameManager.Instance?.AddCrystals(value);
            ScoreManager.Instance?.AddScore(value * 10);
            Destroy(gameObject);
        }
    }
}
EOF
echo done