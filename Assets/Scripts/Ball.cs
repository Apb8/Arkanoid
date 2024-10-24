using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 300.0f;
    private Vector2 velocity;
    Vector2 startPosition;

    public AudioSource audioSource;
    public AudioClip brickSound, loseSound, wallSound;

    void Start()
    {
        startPosition = transform.position;
        ResetBall();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            audioSource.clip = loseSound;
            audioSource.Play();
            FindObjectOfType<GameManager>().LoseHealth();
        }

        if (collision.gameObject.GetComponent<Brick>())
        {
            audioSource.clip = brickSound;
            audioSource.Play();
        }
        
        //if (collision.gameObject.GetComponent<Player>())
        //{
        //    audioSource.clip = playerSound;
        //    audioSource.Play();
        //}

        if (collision.transform.CompareTag("Wall"))
        {
            audioSource.clip = wallSound;
            audioSource.Play();
        }
    }

    public void ResetBall()
    {
        transform.position = startPosition;
        rb.velocity = Vector2.zero;

        velocity.x = Random.Range(-1f, 1f);
        velocity.y = 1;

        rb.AddForce(velocity * speed);
    }
}
