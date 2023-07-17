using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    void destroyEnemy(enemyID, HPEnemy, enemyMoney)
    {
        // 
        HPEnemy = HPEnemy - damageShot;
        HPEnemy = HPEnemy - damageBomb;
        if (HPEnemy < 1)
        {
            //Destruir al enemigo en especifico con su ID
            

        }
    }
}
