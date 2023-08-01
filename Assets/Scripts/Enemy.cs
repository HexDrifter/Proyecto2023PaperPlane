using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] public int health;
    public int damageAmount = 20; // Cantidad de daño que el enemigo hace al jugador.

    private EnemyActivator enemyActivator;

    private void Start()
    {
        gameObject.SetActive(false);
        enemyActivator = GameObject.FindObjectOfType<EnemyActivator>();
    }

    private void OnDestroy()
    {
        if (enemyActivator != null)
        {
            enemyActivator.RemoveEnemy(gameObject);
        }
    }

    public void getDamage(int damage)
    {
        Debug.Log("Enemigo ejecuta");
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Enemigo se destruye");
            Destroy(gameObject);
        }
    }

    public int GetDamageAmount()
    {
        return damageAmount; // Retorna la cantidad de daño que el enemigo hace al jugador.
    }
}
