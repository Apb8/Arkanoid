using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 300.0f;
    private Vector2 velocity;

    void Start()
    {
        velocity.x = Random.Range(-1f, 1f);
        velocity.y = 1;

        rb.AddForce(velocity*speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            FindAnyObjectByType<GameManager>().LoseHealth();
        }
    }
}
