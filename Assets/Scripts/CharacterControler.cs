using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [SerializeField] public float velocidad; // Ahora la variable velocidad es pública para que pueda modificarse desde otros scripts
    [SerializeField] public CinemachineBrain brain;
    [SerializeField] public Rigidbody2D rbody;
    private Vector2 inputMove; // Hice la variable pública para ver el input
    [SerializeField] public GameObject bulletObject;
    [SerializeField] public int bulletDamage;
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
        Vector2 bulletPos;
        bulletPos.x = transform.position.x + 1f;
        bulletPos.y = transform.position.y;
        Instantiate(bulletObject, bulletPos, Quaternion.identity);
        //Vector2 bulletDirection;
        //bulletDirection = new Vector2(1,0)

        BulletController bullet = bulletObject.GetComponent<BulletController>();
        bullet.launch(bulletSpeed, bulletDamage);

    }

    void ProcesarMovimiento()
    {
        inputMove.x = Input.GetAxis("Horizontal");
        inputMove.y = Input.GetAxis("Vertical");

        rbody.velocity = inputMove * velocidad;
    }
}
