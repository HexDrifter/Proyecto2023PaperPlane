using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NubeObstaculo : MonoBehaviour
{
    public float speed;
    public bool moverHorizontal;
    public bool moverVertical;
    public bool esPositivo;
    private Vector3 direccion;

    private void Start()
    {
        // Determinar la dirección de movimiento aleatoriamente
        if (moverHorizontal)
        {
            direccion = (Random.value < 0.5f) ? Vector3.right : Vector3.left;
        }
        else if (moverVertical)
        {
            direccion = (Random.value < 0.5f) ? Vector3.up : Vector3.down;
        }
    }

    private void Update()
    {
        transform.position += direccion * speed * Time.deltaTime;

        // Verificar si alcanzó el límite y cambiar la dirección
        if (moverHorizontal)
        {
            if (esPositivo && transform.position.x >= 10f)
            {
                direccion = Vector3.left;
            }
            else if (!esPositivo && transform.position.x <= -10f)
            {
                direccion = Vector3.right;
            }
        }
        else if (moverVertical)
        {
            if (esPositivo && transform.position.y >= 10f)
            {
                direccion = Vector3.down;
            }
            else if (!esPositivo && transform.position.y <= -10f)
            {
                direccion = Vector3.up;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "square")
        {
            // Cambiar la dirección del objeto
            direccion = -direccion;
        }
    }
}