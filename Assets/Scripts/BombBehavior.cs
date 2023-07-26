using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bombBehavior : MonoBehaviour
{
    public int bombDamage = 100;
    public int currentBombs = 3;
    public int maxBombs = 3;
    private bool isCooldown = false;
    private float lastUsedTime = 0f;
    private float cooldownDuration = 5f;

    private List<Collider> collidersTargets = new List<Collider>();

    // Método para agregar un collider a la lista
    public void AgregarColliderEnemigo(Collider colliderTarget)
    {
        collidersTargets.Add(colliderTarget);
    }

    // Método para eliminar un collider de la lista
    public void EliminarColliderEnemigo(Collider colliderTarget)
    {
        collidersTargets.Remove(colliderTarget);
    }

    // Otros métodos o funcionalidades que puedas necesitar

    void UseBomb()
    {
        /*
        // Obtiene todos los colliders dentro de la zona con el tag "MainCamera" y los almacena en la variable "targets"
        Collider2D[] targets = Physics2D.OverlapBoxAll(transform.position, transform.localScale / 2, 0f, LayerMask.GetMask("MainCamera"));

        foreach (Collider2D target in targets)
        {
            if (target.CompareTag("Enemy"))
            {
                Enemy enemy = target.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.getDamage(bombDamage);
                }
            }
            if (target.CompareTag("EnemyBullet"))
            {
                Destroy(target.gameObject);
            }
        }*/






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
