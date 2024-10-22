using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb; //tmb podria moureho pel transformar i no per les fisiques
    private float inputValue;
    public float moveSpeed = 2.5f;
    //private Vector2 direction; comento pq es del teclado
    Vector2 startPosition;

    public float minX;
    public float maxX;

    // Start is called before the first frame update
    private void Start()
    {
        startPosition = transform.position;

        // Calculo aqui los limites pero tamb puedo hacerlo manualmente en el inspector
        float halfPlayerWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + halfPlayerWidth;
        maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        ////E teoria no hace falta ya q lo hago desde el inspector constraints freeze, mirarse be aquestes 2 linies
        //// Restringir el movimiento solo al eje X, y mantener la Y constante
        Vector2 targetPosition = new Vector2(Mathf.Clamp(worldPosition.x, minX, maxX), transform.position.y);
        // Mover la barra suavemente hacia la posición del mouse
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        rb.velocity = direction * moveSpeed;

        ////Para hacerlo con teclado A-D
        //inputValue = Input.GetAxisRaw("Horizontal");

        //if(inputValue == 1)
        //{
        //    direction = Vector2.right;
        //}
        //else if(inputValue == -1)
        //{
        //    direction = Vector2.left;
        //}
        //else
        //{
        //    direction = Vector2.zero;
        //}

        //rb.AddForce(direction * moveSpeed * Time.deltaTime * 100);
    }

    public void ResetPlayer()
    {
        transform.position = startPosition;
        rb.velocity = Vector2.zero;
    }
}
