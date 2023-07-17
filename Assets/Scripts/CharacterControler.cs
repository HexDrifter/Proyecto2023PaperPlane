using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    public float velocidad; // Ahora la variable velocidad es pública para que pueda modificarse desde otros scripts
    [SerializeField] public CinemachineBrain brain;
    public Rigidbody2D rbody;
    public Vector2 inputMove; // Hice la variable pública para ver el input
    public GameObject bullet;

    public void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        //brain = GetComponent<CinemachineBrain>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shotBullet();
        }
    }

    private void FixedUpdate()
    {
        ProcesarMovimiento();
        brain.ManualUpdate();
    }

    private void shotBullet()
    {
        Debug.Log("Bang");
        Vector2 bulletPos = transform.position;
        bulletPos.x += 0.1f;
        Instantiate(bullet, bulletPos, Quaternion.identity);
        //throw new NotImplementedException();
    }

    void ProcesarMovimiento()
    {
        inputMove.x = Input.GetAxis("Horizontal");
        inputMove.y = Input.GetAxis("Vertical");

        rbody.velocity = inputMove * velocidad;
    }
}
