using UnityEngine;

namespace Vano
{
    /// <summary>
    /// Simple prototype spawner. Spawns crystals and obstacles ahead of the player.
    /// Replace with deterministic chunk-based generator for production.
    /// </summary>
    public class SpawnManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform player;
        [SerializeField] private GameObject crystalPrefab;
        [SerializeField] private GameObject obstaclePrefab;

        [Header("Spawn")]
        [SerializeField] private float spawnDistance = 40f;
        [SerializeField] private float despawnDistance = 20f;
        [SerializeField] private float spawnInterval = 1.5f;
        [SerializeField] private float laneWidth = 8f;

        private float timer;

        void Update()
        {
            if (player == null) return;
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = spawnInterval;
                SpawnOne();
            }
            // despawn behind
            foreach (var c in GameObject.FindGameObjectsWithTag("Crystal"))
                if (c.transform.position.z < player.position.z - despawnDistance) Destroy(c);
            foreach (var o in GameObject.FindGameObjectsWithTag("Obstacle"))
                if (o.transform.position.z < player.position.z - despawnDistance) Destroy(o);
        }

        private void SpawnOne()
        {
            float x = Random.Range(-laneWidth, laneWidth);
            float z = player.position.z + spawnDistance + Random.Range(0f, 10f);
            Vector3 pos = new Vector3(x, 0.5f, z);

            if (Random.value < 0.55f && crystalPrefab != null)
            {
                var c = Instantiate(crystalPrefab, pos, Quaternion.identity);
                c.tag = "Crystal";
            }
            else if (obstaclePrefab != null)
            {
                var o = Instantiate(obstaclePrefab, pos, Quaternion.identity);
                o.tag = "Obstacle";
            }
        }
    }
}
EOF
echo done