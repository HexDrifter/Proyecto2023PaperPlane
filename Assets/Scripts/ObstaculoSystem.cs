using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoSystem : Enemy
{
    // Referencia al objeto que se autodestruirá
    public GameObject objetoAutodestruccion;

    // Método para verificar colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el objeto colisionado tiene la etiqueta "Player" o el nombre "Square"
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.name == "Square")
        {
            // Destruir el objeto actual
            Destroy(objetoAutodestruccion);
        }
    }
}
