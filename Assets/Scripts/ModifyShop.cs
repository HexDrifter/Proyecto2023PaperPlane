using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data.SqlTypes;

public class ModifyShop : MonoBehaviour
{

    public TMP_Text money;
    public TMP_Text maxLife;
    public TMP_Text shotDamage;
    public TMP_Text bombDamage;
    public TMP_Text maxBombs;
    public TMP_Text maxLifeLevel;
    public TMP_Text maxLifeUpgrade;
    public TMP_Text shotDamageLevel;
    public TMP_Text shotDamageUpgrade;
    public TMP_Text bombDamageLevel;
    public TMP_Text bombDamageUpgrade;
    public TMP_Text maxBombsLevel;
    public TMP_Text maxBombsUpgrade;
    public TMP_Text currentLife;
    public TMP_Text currentBombs;
    public TMP_Text nameUpgrade;
    public TMP_Text descriptionUpgrade;
    public TMP_Text nameUpgradeMax;
    public TMP_Text descriptionUpgradeMax;

    // Start is called before the first frame update
    void Start()
    {
        money.text = "Dinero: 1000";
        maxLife.text = "Vida máxima: 100";
        shotDamage.text = "Daño disparo: 25";
        bombDamage.text = "Daño bomba: 100";
        maxBombs.text = "Máx. bombas: 3";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
