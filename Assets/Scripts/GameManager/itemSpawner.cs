using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class itemSpawner : MonoBehaviour
    {
        [SerializeField] private float minSpawnTime;
        [SerializeField] private float maxSpawnTime;

        public BoxCollider2D spawnBoundary;

        public GameObject[] itemsList;

        bool isSpawning = false;

        private void Update()
        {
            if (!isSpawning)
            {
                isSpawning = true;
                StartCoroutine(SpawnItem(UnityEngine.Random.Range(minSpawnTime,maxSpawnTime)));
            }
        }

        IEnumerator SpawnItem(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Vector3 pos = GetRandomPosition();

            int numberOfObjects = Random.Range(0, itemsList.Length);
            GameObject cloud = Instantiate(itemsList[numberOfObjects], pos, Quaternion.identity);
            isSpawning = false;
        }

        private Vector3 GetRandomPosition()
        {
            Bounds bounds = spawnBoundary.bounds;
            float yPos = UnityEngine.Random.Range(bounds.min.y, bounds.max.y);

            return new Vector3(transform.position.x , yPos, 0f);
        }
    }
}

