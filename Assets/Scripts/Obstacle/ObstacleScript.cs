using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float moveSpeed;
    Vector3 moveRight;
    

    private void Start()
    {
        moveRight = new Vector3(10.0f,transform.position.y,0.0f);
        
    }

    private void Update()
    {
        BulletMovement();
        DestroyBullet();
    }
    private void BulletMovement()
    {
        var step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, moveRight, step);
    }

    private void DestroyBullet ()
    {
        if (transform.position.x == 10.0f)
        {
            Destroy(gameObject);
        }
    }

    
}
