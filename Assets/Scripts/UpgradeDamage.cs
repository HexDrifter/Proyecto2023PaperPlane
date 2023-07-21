using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShoot : MonoBehaviour
{
    void upgradeShot(levelUpgradeShot) 
    {
        if (levelUpgradeShot >= 0 && levelUpgradeShot <= 4)
        {
            ShotDamage = damage+5;
            levelUpgradeShot + 1;
        }
    }
    void upgradeShot(levelUpgradeBomb)
    {
        if (levelUpgradeBomb >= 0 && levelUpgradeBomb <= 4)
        {
<<<<<<< HEAD
            BombDamage = damage+5;
            levelUpgradeBomb+1;
=======
            BombDamage = damage + 5;
            levelUpgradeBomb + 1;
>>>>>>> 189a9ad50b4dfafd2f4e7a3576d33873a04ff263
        }
    }
}
