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
        if (moverHorizontal)
        {
            direccion = esPositivo ? Vector3.right : Vector3.left;
        }
        else if (moverVertical)
        {
            direccion = esPositivo ? Vector3.up : Vector3.down;
        }
    }

    private void Update()
    {
        transform.position += direccion * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "square")
        {
            direccion = -direccion;
        }
    }
}
