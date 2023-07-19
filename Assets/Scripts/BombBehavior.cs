using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bombBehavior : Enemy
{
    public int bombDamage = 100;

    void useBomb()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale / 2, 0f, LayerMask.GetMask("Camera"));

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                if ("enemyHealth" != null)
                {
                    // Reducir la vida del enemigo
                }
            }
            if (collider.CompareTag("EnemyBullet"))
            {
                Destroy(collider.gameObject);
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            useBomb();
        }
    }
}
