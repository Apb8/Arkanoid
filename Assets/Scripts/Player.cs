using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb; //tmb podria moureho pel transformar i no per les fisiques
    private float inputValue;
    public float moveSpeed = 2.5f;
    private Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputValue = Input.GetAxisRaw("Horizontal");

        if(inputValue == 1)
        {
            direction = Vector2.right;
        }
        else if(inputValue == -1)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.zero;
        }

        rb.AddForce(direction * moveSpeed * Time.deltaTime * 100);
    }
}
