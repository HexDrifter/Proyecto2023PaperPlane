using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int health;
    
    public void getDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {

            Destroy(gameObject);
        }
    }

    public void Start()
    {
        gameObject.SetActive(false);
    }



}
