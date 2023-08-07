using System.Collections;
using UnityEngine;

public class EnemyNavePapel : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 0.5f;
    public float desiredDistance = 8f; // Distancia deseada del jugador
    public float chaseDistance = 10f; // Distancia para comenzar a perseguir al jugador
    public GameObject bulletPrefab; // Cambiar el tipo del campo a GameObject
    public float shootInterval = 3f;

    private Rigidbody2D rb;
    private Camera mainCamera;

    private float shootTimer = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (player != null)
        {
            // Obtener la posición real del jugador en el mundo
            Vector3 playerWorldPos = mainCamera.transform.TransformPoint(player.position);

            // Calcular la dirección hacia el jugador
            Vector2 directionToPlayer = playerWorldPos - transform.position;

            // Verificar si el jugador está dentro de la distancia de persecución
            if (Mathf.Abs(directionToPlayer.x) <= chaseDistance && Mathf.Abs(directionToPlayer.y) <= chaseDistance)
            {
                ChasePlayer(directionToPlayer);
                ShootBullets(directionToPlayer.normalized);
            }
            else
            {
                rb.velocity = Vector2.zero; // Detener la nave si está fuera de la distancia de persecución
            }
        }
    }

    void ChasePlayer(Vector2 directionToPlayer)
    {
        // Movimiento en el eje X y Y hacia el jugador
        float moveDirectionX = Mathf.Abs(directionToPlayer.x) > desiredDistance ? Mathf.Sign(directionToPlayer.x) : 0f;
        float moveDirectionY = Mathf.Abs(directionToPlayer.y) > desiredDistance ? Mathf.Sign(directionToPlayer.y) : 0f;

        rb.velocity = new Vector2(moveDirectionX * chaseSpeed, moveDirectionY * chaseSpeed);
    }

    void ShootBullets(Vector2 shootDirection)
    {
        if (Time.time >= shootTimer)
        {
            // Asegúrate de que el prefab se pueda instanciar
            if (bulletPrefab != null)
            {
                GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                EnemyBulletController bulletController = bulletInstance.GetComponent<EnemyBulletController>();
                if (bulletController != null)
                {
                    bulletController.Launch(shootDirection, bulletController.bulletSpeed, bulletController.bulletDamage);
                }
            }

            shootTimer = Time.time + shootInterval;
        }
    }
}
