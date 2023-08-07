using System.Collections;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;
    public Rigidbody2D rb;

    private Vector2 bulletDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1);
    }

    void Update()
    {
        rb.velocity = bulletDirection * bulletSpeed;
    }

    public void SetBulletDirection(Vector2 direction)
    {
        bulletDirection = direction.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // Destruir el objeto con la etiqueta "Player"
        }
        Destroy(gameObject); // Destruir la bala
    }

    public void Launch(Vector2 direction, float speed, int damagePoints)
    {
        bulletDirection = direction.normalized;
        bulletDamage = damagePoints;
        bulletSpeed = speed;
    }
}
