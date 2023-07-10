using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VientoObstaculo : MonoBehaviour
{
    public float velocidadRalentizada = -10; // Factor de ralentización del jugador

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Comprueba si el objeto que colisiona tiene la etiqueta "Player"
        {
            Ralentizar(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Comprueba si el objeto ha dejado de colisionar con el jugador
        {
            RestaurarVelocidad(collision.gameObject);
        }
    }

    private void Ralentizar(GameObject jugador)
    {
        Rigidbody2D rb = jugador.GetComponent<Rigidbody2D>();
        rb.velocity *= velocidadRalentizada;
    }

    private void RestaurarVelocidad(GameObject jugador)
    {
        Rigidbody2D rb = jugador.GetComponent<Rigidbody2D>();
        rb.velocity /= velocidadRalentizada;
    }
}

