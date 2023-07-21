using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    //public int damage;
    // Start is called before the first frame update
    public void getDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {

            Destroy(gameObject);
        }
    }

}
