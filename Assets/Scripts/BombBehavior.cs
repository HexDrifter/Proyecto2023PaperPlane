using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bombBehavior : Enemy
{
    public int bombDamage = 100;


    void useBomb()
    {
        /*// Obt�n todos los objetos en la escena con el tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Itera sobre todos los enemigos y reduce su vida
        foreach (GameObject enemy in enemies)
        {
            // Obt�n una referencia al script de vida del enemigo
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

            // Reducir la vida del enemigo llamando a la funci�n correspondiente en su script
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(bombDamage);
            }
        }*/

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            useBomb();
        }
    }
}
