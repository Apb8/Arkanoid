using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 300.0f;
    private Vector2 velocity;
    Vector2 startPosition;
    public float speedIncrement = 1.001f; //0.1%
    public float maxSpeed = 350.0f;
    public float minYVelocity = 0.5f; // velocidad m�nima en Y para evitar estancamientos

    public AudioSource audioSource;
    public AudioClip brickSound, loseSound, wallSound;

    void Start()
    {
        startPosition = transform.position;
        ResetBall();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //rb.velocity *= speedIncrement;

        //if (rb.velocity.magnitude > maxSpeed)
        //{
        //    rb.velocity = rb.velocity.normalized * maxSpeed;
        //}


        ////evitar que la ball se quede atascada en un mismo mov vertical
        //if (Mathf.Abs(rb.velocity.x) < 0.5f)
        //{
        //    float directionX = rb.velocity.x > 0 ? 0.5f : -0.5f;
        //    rb.velocity = new Vector2(directionX, rb.velocity.y).normalized * rb.velocity.magnitude;
        //}

        // Solo incrementa la velocidad si est� por debajo del l�mite
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.velocity *= speedIncrement;
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }

        // Evitar que la bola se quede atascada en movimiento vertical recto
        if (Mathf.Abs(rb.velocity.x) < minYVelocity)
        {
            float directionX = rb.velocity.x > 0 ? minYVelocity : -minYVelocity;
            rb.velocity = new Vector2(directionX, rb.velocity.y).normalized * rb.velocity.magnitude;
        }

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
