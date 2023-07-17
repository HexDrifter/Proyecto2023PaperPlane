using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivator : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCamera"))
        {
            GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemigo in enemigos)
            {
                enemigo.SetActive(true);
            }
        }
    }
}
