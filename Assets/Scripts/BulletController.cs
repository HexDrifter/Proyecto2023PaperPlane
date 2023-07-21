using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] public Vector2 bulletDirection;
    public float bulletSpeed;
    public int bulletDamage;
    public Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
    }

    public void Update()
    {
        rb.velocity = bulletDirection * bulletSpeed ;
    }
    public BulletController(Vector2 Direction)
    {
        bulletDirection = Direction;
    }

    // Update is called once per frame


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.getDamage(bulletDamage);
        }
        Destroy(gameObject);
    }

    public void launch(float speed, int damagePoints)
    {
        bulletDamage = damagePoints;
        bulletSpeed = speed;
    }
}
