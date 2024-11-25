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
      var step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,moveDown,step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        {
            Debug.Log("getting called");
            Destroy(gameObject);
        }
    }

    
}
