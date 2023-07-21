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
    [SerializeField] public int bombDamage;
    [SerializeField] public int currentBombs;
    [SerializeField] public int maxBombs;
    private bool isCooldown = false;
    private float lastUsedTime = 0f;
    [SerializeField] private float bombCooldownDuration;

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
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isCooldown && currentBombs > 0)
        {
            UseBomb();
        }

        // Verifica si el cooldown ha terminado
        if (isCooldown && Time.time - lastUsedTime >= bombCooldownDuration)
        {
            isCooldown = false;
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

    void UseBomb()
    {
        // Obtiene todos los colliders dentro de la zona con el tag "MainCamera" y los almacena en la variable "targets"
        Collider2D[] targets = Physics2D.OverlapBoxAll(transform.position, transform.localScale / 2, 0f, LayerMask.GetMask("MainCamera"));

        foreach (Collider2D target in targets)
        {
            if (target.CompareTag("Enemy"))
            {
                Destroy(target.gameObject);
                /*Enemy enemy = target.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.getDamage(bombDamage);
                }*/
            }
            if (target.CompareTag("EnemyBullet"))
            {
                Destroy(target.gameObject);
            }
        }
        currentBombs--;
        //Cooldown para no spamear la bomba
        isCooldown = true;
        lastUsedTime = Time.time;
    }
}
