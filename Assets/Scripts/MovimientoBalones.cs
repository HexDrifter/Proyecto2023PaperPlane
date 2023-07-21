using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBalones : Enemy
{
    [SerializeField] public float moveSpeed = 5f; // Velocidad de movimiento horizontal
    public float jumpHeight = 2f; // Altura del salto (parábola)
    public bool izquierda = false; // Variable para controlar la dirección izquierda o derecha

    private float timeCounter = 0f;
    private Vector2 initialPosition;
    private Vector2 moveDirection;

    private bool hasJumped = false; // Variable para controlar si el balón ha saltado

    void Start()
    {
        initialPosition = transform.position;
        moveDirection = izquierda ? Vector2.left : Vector2.right;
        /*
        rb = GetComponent<Rigidbody>();
        rb.velocity = balonDireccion;
        */
    }

    void Update()
    {
        // Si el balón aún no ha saltado, calculamos la posición vertical y horizontal en función del tiempo
        if (!hasJumped)
        {
            timeCounter += Time.deltaTime;
            float x = initialPosition.x + moveDirection.x * moveSpeed * timeCounter;
            float y = initialPosition.y + (jumpHeight * 4 * timeCounter) - (jumpHeight * 4 * timeCounter * timeCounter);

            // Actualizamos la posición del balón
            transform.position = new Vector2(x, y);

            // Si el balón ha alcanzado la altura máxima del salto, cambiamos la dirección vertical y marcamos que ha saltado
            if (y >= initialPosition.y + jumpHeight)
            {
                hasJumped = true;
            }
        }
        else
        {
            // Si el balón ya ha saltado, destruimos el objeto
            Destroy(gameObject);
        }
    }
}
