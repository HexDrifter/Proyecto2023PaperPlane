using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VientoObstaculo : MonoBehaviour
{
    public float velocidadRalentizada = 0.5f; // Factor de ralentización del jugador

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Comprueba si el objeto que colisiona tiene la etiqueta "Player"
        {
            Ralentizar(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Comprueba si el objeto ha dejado de colisionar con el jugador
        {
            RestaurarVelocidad(other.gameObject);
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

