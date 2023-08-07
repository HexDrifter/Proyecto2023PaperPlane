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
            // Acceder al GameManager y enviar el daño al jugador
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GetDamage(GameManager.Instance.damageAmount);
            }
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
