using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bombBehavior : Enemy
{
    public int bombDamage = 100;

    void UseBomb()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale / 2, 0f, LayerMask.GetMask("MainCamera"));

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Destroy(collider.gameObject); //Linea para testear
                /*if ("enemyHealth" < 1)
                {
                    //Reducir la vida del enemigo
                }*/
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
            UseBomb();
        }
    }
}
