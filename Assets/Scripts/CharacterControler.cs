using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    public float velocidad;

    void Update()
    {
        ProcesarMovimiento();
    }

    // Update is called once per frame
    void ProcesarMovimiento()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.velocity = new Vector2(inputHorizontal * velocidad, inputVertical * velocidad);
    }
}