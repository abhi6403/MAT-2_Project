using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfinityJumper.Game
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private float minSpawnTime;
        [SerializeField] private float maxSpawnTime;

        public BoxCollider2D spawnBoundary;

        public GameObject[] objectList;

        bool isSpawning = false;

        private float lastSpawnTime;

        private void Update()
        {
            if (!isSpawning)
            {
                float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
                
                if (Time.time >= lastSpawnTime + waitTime)
                {
                    isSpawning = true;
                    SpawnItem();
                    lastSpawnTime = Time.time;
                }
            }
        }

        private void SpawnItem()
        {
            Vector3 pos = GetRandomPosition();

            int numberOfObjects = Random.Range(0, objectList.Length);
            GameObject obj = Instantiate(objectList[numberOfObjects], pos, Quaternion.identity);
            isSpawning = false;
        }
        
        public Vector3 GetRandomPosition()
        {
            
            Bounds bounds = spawnBoundary.bounds;
            float yPos = UnityEngine.Random.Range(bounds.min.y, bounds.max.y);
            float xPos = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);

            return new Vector3(xPos, yPos, 0);
        }
    }
}

