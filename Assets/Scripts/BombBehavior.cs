using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bombBehavior : Enemy
{
    public int bombDamage = 100;
    void useBomb()
    {
        
    }
    private void Update()
    {
        if (Input.GetKey("ctrl"))
        {
            useBomb();
        }
    }
}
