using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerEnemy : MonoBehaviour
{
    public Vector2 bulletDirection;
    public float bulletSpeed;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
    }

    void Update()
    {
        rb.velocity = bulletDirection * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Comprobar si el objeto colisionado tiene la etiqueta "Player"
        {
            // Aquí puedes realizar cualquier acción que desees cuando la bala colisione con el jugador.
            // Por ejemplo, puedes hacer que el jugador pierda salud directamente sin depender de un componente de vida.
            Debug.Log("La bala ha golpeado al jugador.");
            // Puedes agregar aquí cualquier otra lógica que desees ejecutar cuando la bala golpee al jugador.
        }

        Destroy(gameObject);
    }

    public void Launch(float speed, Vector2 direction)
    {
        bulletSpeed = speed;
        bulletDirection = direction.normalized;
    }
}
