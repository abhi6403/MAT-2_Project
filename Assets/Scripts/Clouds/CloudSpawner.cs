using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnTime;

    public BoxCollider2D spawnBoundary;

    public GameObject cloudObject;

    bool isSpawning = false;

    private void Update()
    {
        if(!isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnCloud(spawnTime));
        }
    }
    IEnumerator SpawnCloud(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Vector3 pos = GetRandomPosition();

        GameObject cloud = Instantiate(cloudObject, pos, Quaternion.identity);
        isSpawning = false;
    }

    private Vector3 GetRandomPosition()
    {
        Bounds bounds = spawnBoundary.bounds;
        float xPos = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
     
        return new Vector3(xPos,transform.position.y,0f);
    }
}
