using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloundController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    

    Vector3 moveDown;


    private void Start()
    {
        moveDown = new Vector3(-1,-9.0f,0.0f);
        
        
    }
    private void Update()
    {
        CloudMovement();
        DestroyCloud();
    }

    private void DestroyCloud()
    {
        if (transform.position.y == -9.0f)
        {
            Destroy(gameObject);
        }
    }

    private void CloudMovement()
    {
        var step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, moveDown, step);
    }

    

}
