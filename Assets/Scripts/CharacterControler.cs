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
    [SerializeField] public float bulletSpeed;

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
        //Vector2 bulletDirection;
        //bulletDirection = new Vector2(1,0)
        


        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

        // Aplicar velocidad a la bala en la dirección hacia arriba (puedes ajustar esto según tus necesidades)
        rbBullet.velocity = transform.right * bulletSpeed * Time.deltaTime;
        
    }

    void ProcesarMovimiento()
    {
        inputMove.x = Input.GetAxis("Horizontal");
        inputMove.y = Input.GetAxis("Vertical");

        rbody.velocity = inputMove * velocidad;
    }
}
