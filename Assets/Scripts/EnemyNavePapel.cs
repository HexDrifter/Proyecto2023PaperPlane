using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavePapel : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 5f;
    public float desiredDistance = 5f; // Distancia deseada del jugador
    public float chaseDistance = 10f; // Distancia para comenzar a perseguir al jugador

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
            }
        }
    }

    void ChasePlayer(float distanceToPlayerX, float distanceToPlayerY)
    {
        // Movimiento en el eje X para mantener la distancia deseada
        if (Mathf.Abs(distanceToPlayerX) > desiredDistance)
        {
            float moveDirectionX = Mathf.Sign(distanceToPlayerX);
            transform.Translate(Vector3.right * moveDirectionX * chaseSpeed * Time.deltaTime);
        }

        // Movimiento en el eje Y para mantener la distancia deseada
        if (Mathf.Abs(distanceToPlayerY) > desiredDistance)
        {
            float moveDirectionY = Mathf.Sign(distanceToPlayerY);
            transform.Translate(Vector3.up * moveDirectionY * chaseSpeed * Time.deltaTime);
        }
    }
}
