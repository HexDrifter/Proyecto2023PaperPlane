using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data.SqlTypes;

public class ModifyShop : MonoBehaviour
{
    public Button buy;
    public TMP_Text buyText;
    public TMP_Text moneyText;
    public TMP_Text maxLifeText;
    public TMP_Text shotDamageText;
    public TMP_Text bombDamageText;
    public TMP_Text maxBombsText;
    public TMP_Text maxLifeLevelText;
    public TMP_Text maxLifeUpgradeText;
    public TMP_Text shotDamageLevelText;
    public TMP_Text shotDamageUpgradeText;
    public TMP_Text bombDamageLevelText;
    public TMP_Text bombDamageUpgradeText;
    public TMP_Text maxBombsLevelText;
    public TMP_Text maxBombsUpgradeText;
    public TMP_Text currentLifeText;
    public TMP_Text currentBombsText;
    public TMP_Text nameUpgradeText;
    public TMP_Text descriptionUpgradeText;

    private int money = 100000;
    private int maxLife = 100;
    private int shotDamage = 25;
    private int bombDamage = 100;
    private int maxBombs = 3;

    // Start is called before the first frame update
    void Start()
    {
        // TEST
        moneyText.text = "Dinero: " + money.ToString();
        maxLife.text = "Vida máxima: " + maxLife.ToString();
        shotDamage.text = "Daño disparo: " + shotDamage.ToString();
        bombDamage.text = "Daño bomba: " + bombDamage.ToString();
        maxBombs.text = "Máx. bombas: " + maxBombs.ToString();
        buy.interactable = false;
        buyText.text = "MAX";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
