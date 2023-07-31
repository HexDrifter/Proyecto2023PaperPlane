using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;
    public Rigidbody2D rb;


    private static Vector2 bulletDirection;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1);
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
        Rigidbody2D rbcol = collision.collider.GetComponent<Rigidbody2D>();
        if (rbcol != null)
        {
            rbcol.simulated = false;
        }
        IDamageable damageable = collision.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log("Bala impacta");
            damageable.getDamage(bulletDamage);
        }

        if (rbcol != null)
        {
            rbcol.simulated = true;
        }
        Destroy(gameObject);
    }
    public static void SetBulletDirection(Vector2 direction)
    {
        bulletDirection = direction.normalized;
    }
    public void launch(float speed, int damagePoints)
    {
        bulletDamage = damagePoints;
        bulletSpeed = speed;
    }
}
