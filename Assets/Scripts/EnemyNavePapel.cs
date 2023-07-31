using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavePapel : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 5f;
    public float desiredDistance = 5f; // Distancia deseada del jugador
    public float chaseDistance = 10f; // Distancia para comenzar a perseguir al jugador

    public GameObject bulletPrefab;
    public float bulletSpeed = 10f; // Velocidad de la bala
    public int bulletDamage = 25; // Daño de la bala
    public float cooldown = 0.7f; // Cooldown entre disparos
    private bool canShoot = true;

    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayerX = player.position.x - transform.position.x;
            float distanceToPlayerY = player.position.y - transform.position.y;

            float distanceToPlayer = Mathf.Sqrt(distanceToPlayerX * distanceToPlayerX + distanceToPlayerY * distanceToPlayerY);

            // Persigue al jugador si está dentro de la distancia de persecución
            if (distanceToPlayer <= chaseDistance)
            {
                ChasePlayer(distanceToPlayerX, distanceToPlayerY);

                // Disparar si el cooldown ha terminado
                if (canShoot)
                {
                    StartCoroutine(ShootCooldown());
                    ShootAtPlayer();
                }
            }
        }
    }

    void ChasePlayer(float distanceToPlayerX, float distanceToPlayerY)
    {
        // Movimiento en el eje X para mantener la distancia deseada
        if (Mathf.Abs(distanceToPlayerX) > desiredDistance)
        {
            float moveDirectionX = Mathf.Sign(distanceToPlayerX);
            rb.velocity = new Vector2(moveDirectionX * chaseSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        // Movimiento en el eje Y para mantener la distancia deseada
        if (Mathf.Abs(distanceToPlayerY) > desiredDistance)
        {
            float moveDirectionY = Mathf.Sign(distanceToPlayerY);
            rb.velocity = new Vector2(rb.velocity.x, moveDirectionY * chaseSpeed);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }

    void ShootAtPlayer()
    {
        Vector2 bulletDirection = player.position - transform.position;
        bulletDirection = bulletDirection.normalized; // Normalizamos la dirección para asegurarnos de que tenga magnitud 1
        Vector2 bulletSpawnPosition = (Vector2)transform.position + bulletDirection * 1f; // Distancia de 1 unidad desde la nave enemiga
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.identity);
        bullet.GetComponent<BulletControllerEnemy>().Launch(bulletSpeed, bulletDirection);
    }


    IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}
