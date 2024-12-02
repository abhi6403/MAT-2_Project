using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int jumpForce;
    [SerializeField]
    private GameObject jetFlame;
    [SerializeField]
    private GameObject baseCloud;
    [SerializeField]
    private ScoreController scoreController;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject scoreText;

    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    private BoxCollider2D playerCollider;

    bool isShieldActive = false;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();

        Time.timeScale = 0;
        StartCoroutine(DestroybaseCloud());
    }

    private void Update()
    {
        Horizontalmovement();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cloud"))
        {
            SoundManager.Instance.Play(Sounds.PLAYERJUMP);
            playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            playerAnimator.SetBool("Jump", true);
        }
        else if (collision.gameObject.CompareTag("Jet"))
        {
            SoundManager.Instance.Play(Sounds.POWERUP);
            Destroy(collision.gameObject);
            Debug.Log("getting called");
            StartCoroutine(JetPower());
        }
        else if(collision.gameObject.CompareTag("Shield") && isShieldActive == false)
        {
            SoundManager.Instance.Play(Sounds.POWERUP);
            Destroy(collision.gameObject);
            Debug.Log("getting called");
            StartCoroutine(ShieldPower());
        }
        else if(collision.gameObject.CompareTag("Bullet") && isShieldActive == false)
        {
            SoundManager.Instance.Play(Sounds.PLAYERDEATH);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            scoreText.SetActive(false);
            gameOver.SetActive(true);
            SoundManager.Instance.Play(Sounds.GAMEOVER);
            Time.timeScale = 0;
        }else if(collision.gameObject.CompareTag("Destroy"))
        {
            SoundManager.Instance.Play(Sounds.PLAYERDEATH);
            Destroy(gameObject);
            scoreText.SetActive(false);
            gameOver.gameObject.SetActive(true);
            SoundManager.Instance.Play(Sounds.GAMEOVER);
            Time.timeScale = 0;
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
        playerRb.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
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

    private IEnumerator DestroybaseCloud()
    {
        yield return new WaitForSeconds(10);
        baseCloud.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
            scoreController.IncreaseScore(1);
    }
}
