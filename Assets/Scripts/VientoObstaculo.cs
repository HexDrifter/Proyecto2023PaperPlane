using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VientoObstaculo : MonoBehaviour
{
    public float factorRalentizacion = 0.5f; // Factor de ralentización del jugador
    private List<Rigidbody2D> jugadoresRalentizados = new List<Rigidbody2D>();

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
        Rigidbody2D jugadorRigidbody = jugador.GetComponent<Rigidbody2D>();
        if (!jugadoresRalentizados.Contains(jugadorRigidbody))
        {
            jugadoresRalentizados.Add(jugadorRigidbody);
        }
    }

    private void RestaurarVelocidad(GameObject jugador)
    {
        Rigidbody2D jugadorRigidbody = jugador.GetComponent<Rigidbody2D>();
        if (jugadoresRalentizados.Contains(jugadorRigidbody))
        {
            jugadoresRalentizados.Remove(jugadorRigidbody);
        }
    }

    private void FixedUpdate()
    {
        foreach (Rigidbody2D jugadorRigidbody in jugadoresRalentizados)
        {
            Vector2 nuevaVelocidad = jugadorRigidbody.velocity * factorRalentizacion;
            jugadorRigidbody.velocity = nuevaVelocidad;
        }
    }
}
