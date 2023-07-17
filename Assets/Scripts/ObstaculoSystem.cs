using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoSystem : MonoBehaviour
{
    // Referencia al objeto que se autodestruirá
    public GameObject objetoAutodestruccion;

    // Etiqueta del objeto jugador
    public string etiquetaJugador = "player";

    // Método para verificar colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si la etiqueta de colisión es la del jugador
        if (collision.gameObject.CompareTag(etiquetaJugador))
        {
            // Destruir el objeto actual
            Destroy(objetoAutodestruccion);
        }
    }
}
