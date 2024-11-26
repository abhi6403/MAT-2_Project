using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int jumpForce;
    [SerializeField]
    private GameObject jetFlame;

    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    private BoxCollider2D playerCollider;

    bool isShieldActive = false;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Horizontalmovement();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cloud"))
        {
            playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            playerAnimator.SetBool("Jump", true);
        }
        else if (collision.gameObject.CompareTag("Jet"))
        {
            Destroy(collision.gameObject);
            Debug.Log("getting called");
            StartCoroutine(JetPower());
        }
        else if(collision.gameObject.CompareTag("Shield") && isShieldActive == false)
        {
            Destroy(collision.gameObject);
            Debug.Log("getting called");
            StartCoroutine(ShieldPower());
        }
        else if(collision.gameObject.CompareTag("Bullet") && isShieldActive == false)
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);
        }
    }

    private void Horizontalmovement()
    {
        Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mouseposition.x, transform.position.y);
    }

    private IEnumerator JetPower()
    {
        playerCollider.isTrigger = true;
        jetFlame.SetActive(true);
        playerRb.constraints = RigidbodyConstraints2D.FreezePositionY;
        yield return new WaitForSeconds(5);
        jetFlame.SetActive(false);
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerCollider.isTrigger = false;
    }

    private IEnumerator ShieldPower()
    {
        isShieldActive = true;
        yield return new WaitForSeconds(5);
        isShieldActive = false;
    }
}
