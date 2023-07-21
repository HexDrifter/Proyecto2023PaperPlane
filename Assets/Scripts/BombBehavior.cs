using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bombBehavior : Enemy
{
    public int bombDamage = 100;
    public int currentBombs = 3;
    public int maxBombs = 3;
    private bool isCooldown = false;
    private float lastUsedTime = 0f;
    private float cooldownDuration = 5f;

    void UseBomb()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale / 2, 0f, LayerMask.GetMask("MainCamera"));

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Destroy(collider.gameObject); //Linea para testear
                // Agregar una funcion para reducir la vida del enemigo
            }
            if (collider.CompareTag("EnemyBullet"))
            {
                Destroy(collider.gameObject);
            }
        }
        currentBombs--;
        //Cooldown para no spamear la bomba
        isCooldown = true;
        lastUsedTime = Time.time;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isCooldown && currentBombs > 0)
        {
            UseBomb();
        }

        // Verifica si el cooldown ha terminado
        if (isCooldown && Time.time - lastUsedTime >= cooldownDuration)
        {
            isCooldown = false;
        }
    }
}
