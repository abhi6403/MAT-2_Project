using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int jumpForce;

    private Rigidbody2D playerRb;
    private Animator playerAnimator;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Horizontalmovement();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cloud"))
        {
            playerRb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
            playerAnimator.SetBool("Jump", true);
        } else
        {
            playerAnimator.SetBool("Jump", false);
        }
    }

    private void Horizontalmovement()
    {
        Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mouseposition.x, transform.position.y);
    }
}
