//using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rbody;
    [SerializeField] public float velocidad; 


    private Vector2 inputMove;
    

    [SerializeField] public GameObject bulletObject;
    [SerializeField] public int bulletDamage;
    [SerializeField] public float bulletSpeed;
    [SerializeField] public int bombDamage;
    [SerializeField] public int currentBombs;//hay que pasarlo al gameManager
    [SerializeField] public int maxBombs;//Hay que pasarlo al gameManager


    
    [SerializeField] private float bombCooldownDuration;
    [SerializeField] public float shotCoolDown;
    [SerializeField] private float timeLeftShot;

    private bool isCooldown = false;
    private float lastUsedTime = 0f;

    private Camera mainCamera;
    private float shipWidth;
    private float shipHeight;

    public void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        shipWidth = GetComponent<Renderer>().bounds.extents.x;
        shipHeight = GetComponent<Renderer>().bounds.extents.y;
    }

    void FixedUpdate()
    {
        ProcesarMovimiento();
        RestrictToScreen();
    }

    void RestrictToScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 cameraBoundsMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 cameraBoundsMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));
        
        newPosition.x = Mathf.Clamp(newPosition.x, cameraBoundsMin.x + shipWidth, cameraBoundsMax.x - shipWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, cameraBoundsMin.y + shipHeight, cameraBoundsMax.y - shipHeight);
        transform.position = newPosition;
    }

    void Update()
    {

        readShotBullet();



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

    private void readShotBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space) && timeLeftShot <= 0)
        {

            shotBullet();
            timeLeftShot = shotCoolDown;
        }
        else if (Input.GetKey(KeyCode.Space) && timeLeftShot <= 0)
        {
            shotBullet();
            timeLeftShot = shotCoolDown;
        }
        if (timeLeftShot > 0)
        {
            timeLeftShot -= Time.deltaTime;
        }
    }

    private void shotBullet()
    {
        Vector2 bulletPos;
        bulletPos.x = transform.position.x + 1f;
        bulletPos.y = transform.position.y;
        
        Instantiate(bulletObject, bulletPos, Quaternion.identity);

        BulletController.SetBulletDirection(Vector2.right);
        
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
