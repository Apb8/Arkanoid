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

    public bool isAutoMode = false;
    public GameObject ball;

    //[SerializeField] private GameObject extendedPlayerPrefab;
    //private GameObject currentPlayer; 
    //private bool isExtended = false;
    //public float extensionDuration = 5f;
    //private float extensionTimer;

    // Start is called before the first frame update
    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();

        startPosition = transform.position;

        //currentPlayer = this.gameObject;

        // Calculo aqui los limites pero tamb puedo hacerlo manualmente en el inspector
        float halfPlayerWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + halfPlayerWidth;
        maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfPlayerWidth;
                
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mousePosition = Input.mousePosition;

        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //////E teoria no hace falta ya q lo hago desde el inspector constraints freeze, mirarse be aquestes 2 linies
        ////// Restringir el movimiento solo al eje X, y mantener la Y constante
        //Vector2 targetPosition = new Vector2(Mathf.Clamp(worldPosition.x, minX, maxX), transform.position.y);
        //// Mover la barra suavemente hacia la posición del mouse
        //Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        //rb.velocity = direction * moveSpeed;

        //Modo automatico
        if(Input.GetKeyDown(KeyCode.Q))
        {
            isAutoMode = !isAutoMode;
        }

        //if (isExtended)
        //{
        //    extensionTimer -= Time.deltaTime;
        //    if (extensionTimer <= 0)
        //    {
        //        ResetSize();
        //    }
        //}
            //// Obtener la posición del mouse -- esto lo he puesto en manual move
            //Vector3 mousePosition = Input.mousePosition;
            //// Convertir la posición del mouse en coordenadas del mundo
            //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //// Restringir el movimiento solo al eje X
            //float targetX = Mathf.Clamp(worldPosition.x, minX, maxX);
            //// Mover la barra a la posición objetivo
            //rb.velocity = new Vector2((targetX - transform.position.x) * moveSpeed, rb.velocity.y);

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

    //uso fixed update porq el player se mueve con fisicas y no con transform
    private void FixedUpdate()
    {
        if(isAutoMode)
        {
            AutoMove();
        }
        else
        {
            ManualMove();
        }
    }

    void AutoMove()
    {
        // Obtener la posición X de la bola
        float targetX = Mathf.Clamp(ball.transform.position.x, minX, maxX);

        // Mover la barra hacia la posición de la bola en el eje X
        rb.velocity = new Vector2((targetX - transform.position.x) * moveSpeed, rb.velocity.y);
    }

    void ManualMove()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        float targetX = Mathf.Clamp(worldPosition.x, minX, maxX);
        rb.velocity = new Vector2((targetX - transform.position.x) * moveSpeed, rb.velocity.y);
    }

    public void ResetPlayer()
    {
        transform.position = startPosition;
        rb.velocity = Vector2.zero;

        //if (currentPlayer != null)
        //{
        //    Destroy(currentPlayer); // Destruye el jugador actual si existe
        //}

        //// Reinstancia el jugador original sin el power-up
        //currentPlayer = Instantiate(this.gameObject, startPosition, Quaternion.identity);
        //currentPlayer.transform.parent = transform.parent;

        //rb = currentPlayer.GetComponent<Rigidbody2D>(); // Actualiza la referencia de Rigidbody2D
        //isExtended = false; // Asegúrate de que isExtended esté en falso
        //extensionTimer = 0f; // Reiniciar el temporizador de extensión
    }

    public void ExtendSize()
    {
        //if (!isExtended)
        //{
        //    Destroy(currentPlayer); // Destruir la barra actual

        //    // Instanciar la barra extendida
        //    currentPlayer = Instantiate(extendedPlayerPrefab, transform.position, Quaternion.identity);
        //    currentPlayer.transform.parent = transform.parent;

        //    // Obtener el script Player del nuevo objeto
        //    var extendedPlayerScript = currentPlayer.GetComponent<Player>();
        //    if (extendedPlayerScript != null)
        //    {
        //        extendedPlayerScript.ball = this.ball; // Asignar la bola al nuevo Player
        //    }

        //    rb = currentPlayer.GetComponent<Rigidbody2D>(); // Actualizar referencia de Rigidbody2D
        //    isExtended = true;
        //    extensionTimer = extensionDuration;

        //    float halfPlayerWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        //    minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + halfPlayerWidth;
        //    maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfPlayerWidth;
        //}
    }

    private void ResetSize()
    {
        //Vector2 currentPosition = transform.position;
        //Destroy(currentPlayer); // Destruir la barra extendida

        //// Instanciar el prefab original
        //currentPlayer = Instantiate(this.gameObject, currentPosition, Quaternion.identity);
        //currentPlayer.transform.parent = transform.parent;

        //// Asignar el Rigidbody2D y otros parámetros
        //var newPlayerScript = currentPlayer.GetComponent<Player>();
        //if (newPlayerScript != null)
        //{
        //    newPlayerScript.minX = minX;
        //    newPlayerScript.maxX = maxX;
        //    newPlayerScript.rb = currentPlayer.GetComponent<Rigidbody2D>();
        //    newPlayerScript.isAutoMode = isAutoMode; // Mantener el modo de movimiento
        //}

        //rb = currentPlayer.GetComponent<Rigidbody2D>();
        //isExtended = false;
    }
}
