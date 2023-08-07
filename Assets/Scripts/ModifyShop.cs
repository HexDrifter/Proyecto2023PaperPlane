using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Data.SqlTypes;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class ModifyShop : MonoBehaviour
{
    public Button buy;
    public Button closePopup;
    public Button selectMaxLife;
    public Button selectShotDamage;
    public Button selectBombDamage;
    public Button selectMaxBombs;
    public Button selectBuyLife;
    public Button selectBuyBombs;

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

    private string maxLifeInfo = "Aumenta la vida máxima de la nave.";
    private string shotDamageInfo = "Aumenta el daño de los disparos de la nave.";
    private string bombDamageInfo = "Aumenta el daño de las bombas de la nave.";
    private string maxBombsInfo = "Aumenta el número máximo de bombas que se pueden llevar la nave.";
    private string buyLifeInfo = "Repara los daños que ha recibido la nave.";
    private string buyBombsInfo = "Compra bombas adicionales para la nave.";

    public GameObject selectPanel;
    public GameObject infoPanel;
    public GameObject popup;
    public GameObject blockPanel;

    private int levelMaxLife = 0;
    private int levelShotDamage = 0;
    private int levelBombDamage = 0;
    private int levelMaxBombs = 0;

    private int TempLevelMaxLife;
    private int TempLevelShotDamage;
    private int TempLevelBombDamage;
    private int TempLevelMaxBombs;

    private int currentLife = 100;
    private int currentBombs = 3;
    private int money = 100000;
    private int maxLife = 100;
    private int shotDamage = 25;
    private int bombDamage = 100;
    private int maxBombs = 3;

    private int TempMaxLife;
    private int TempShotDamage;
    private int TempBombDamage;
    private int TempMaxBombs;

    void UpdateInfo()
    {
        moneyText.text = "Dinero: " + money.ToString();
        maxLifeText.text = "Vida máxima: " + maxLife.ToString();
        shotDamageText.text = "Daño disparo: " + shotDamage.ToString();
        bombDamageText.text = "Daño bomba: " + bombDamage.ToString();
        maxBombsText.text = "Máx. bombas: " + maxBombs.ToString();
    }
    void ShowInfoPanel(string title, string description)
    {
        nameUpgradeText.text = title;
        descriptionUpgradeText.text = description;
        selectPanel.SetActive(false);
        infoPanel.SetActive(true);
    }
    void ClosePopup()
    {
        popup.SetActive(false);
        blockPanel.SetActive(false);
    }
    void BuyUpgrade()
    {
        // Verificar si tienes suficiente dinero para la compra.
        if (money >= 1000)
        {
            money -= 1000;
        }
        else
        {
            Debug.Log("No tienes suficiente dinero para comprar la mejora.");
            popup.SetActive(true);
            blockPanel.SetActive(true);
        }
    }

    void ShowMaxLifeInfo()
    {
        if (levelMaxLife < 5)
        {
            buy.interactable = true;
            buyText.text = "Comprar";
            //buy.onClick.RemoveAllListeners();
            //buy.onClick.AddListener(UpgradeMaxLife);
        }
        ShowInfoPanel("Mejorar vida máxima", maxLifeInfo);
    }

    void ShowShotDamageInfo()
    {
        if (levelShotDamage < 5)
        {
            buy.interactable = true;
            buyText.text = "Comprar";
            buy.onClick.RemoveAllListeners();
            buy.onClick.AddListener(UpgradeShotDamage);
        }
        ShowInfoPanel("Mejorar daño del disparo", shotDamageInfo);
        
    }

    void ShowBombDamageInfo()
    {
        if (levelBombDamage < 5)
        {
            buy.interactable = true;
            buyText.text = "Comprar";
            buy.onClick.RemoveAllListeners();
            buy.onClick.AddListener(UpgradeBombDamage);
        }
        ShowInfoPanel("Mejorar daño de bombas", bombDamageInfo);
    }

    void ShowMaxBombsInfo()
    {
        if (levelMaxBombs < 5)
        {
            buy.interactable = true;
            buyText.text = "Comprar";
            //buy.onClick.RemoveAllListeners();
            //buy.onClick.AddListener(UpgradeMaxBombs);
        }
        ShowInfoPanel("Mejorar máximo de bombas", maxBombsInfo);
    }

    void ShowBuyLifeInfo()
    {
        ShowInfoPanel("Reparar nave", buyLifeInfo);
        buy.onClick.AddListener(BuyUpgrade);
    }

    void ShowBuyBombsInfo()
    {
        ShowInfoPanel("Recargar bombas", buyBombsInfo);
        buy.onClick.AddListener(BuyUpgrade);
    }

    void UpgradeShotDamage()
    {
        if (levelShotDamage < 5 && money >= 1000)
        {
            shotDamage += 5;
            levelShotDamage += 1;
            BuyUpgrade();
            if (levelShotDamage > 4)
            {
                buy.interactable = false;
                buyText.text = "MAX";
            }
        }
        else
        {
            BuyUpgrade();
        }
    }
    void UpgradeBombDamage()
    {
        if (levelBombDamage < 5 && money >=1000)
        {
            bombDamage += 20;
            levelBombDamage += 1;
            BuyUpgrade();
            if (levelBombDamage > 4)
            {
                buy.interactable = false;
                buyText.text = "MAX";
            }
        }
        else
        {
            BuyUpgrade();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TempLevelMaxLife = levelMaxLife+1;
        TempLevelShotDamage = levelShotDamage+1;
        TempLevelBombDamage = levelBombDamage+1;
        TempLevelMaxBombs = levelMaxBombs+1;

        TempMaxLife = maxLife+20;
        TempShotDamage = shotDamage+5;
        TempBombDamage = bombDamage+20;
        TempMaxBombs = maxBombs+1;

        selectPanel.SetActive(true);
        infoPanel.SetActive(false);

        UpdateInfo();

        if (levelMaxLife > 5) {
            maxLifeLevelText.text = "Nivel 5";
            maxLifeUpgradeText.text = "Máximo 200";
        }
        else{
            maxLifeLevelText.text = "Nivel " + levelMaxLife.ToString() + " > Nivel " + TempLevelMaxLife.ToString();
            maxLifeUpgradeText.text = "Máximo " + maxLife.ToString() + " > Máximo " + TempMaxLife.ToString();
        }
        if (levelShotDamage > 5){
            bombDamageLevelText.text = "Nivel 5";
            bombDamageUpgradeText.text = "Daño 50";
        }
        else{
            bombDamageLevelText.text = "Nivel " + levelBombDamage.ToString() + " > Nivel " + TempLevelBombDamage.ToString();
            bombDamageUpgradeText.text = "Daño " + bombDamage.ToString() + " > Daño " + TempBombDamage.ToString();
        }
        if (levelBombDamage > 5){
            shotDamageLevelText.text = "Nivel 5";
            shotDamageUpgradeText.text = "Daño 200";
        }
        else{
            shotDamageLevelText.text = "Nivel " + levelShotDamage.ToString() + " > Nivel " + TempLevelShotDamage.ToString();
            shotDamageUpgradeText.text = "Daño " + shotDamage.ToString() + " > Daño " + TempShotDamage.ToString();
        }
        if (levelMaxBombs > 5){
            maxBombsLevelText.text = "Nivel 5";
            maxBombsUpgradeText.text = "Máximo 9";
        }
        else{
            maxBombsLevelText.text = "Nivel " + levelMaxBombs.ToString() + " > Nivel " + TempLevelMaxBombs.ToString();
            maxBombsUpgradeText.text = "Máximo " + maxBombs.ToString() + " > Máximo " + TempMaxBombs.ToString();
        }
        
        currentLifeText.text = currentLife + " / " + maxLife;
        currentBombsText.text = currentBombs + " / " + maxBombs;

        //buy.interactable = false;
        //buyText.text = "MAX";

        if (levelBombDamage > 5) { 
        
        }

        selectMaxLife.onClick.AddListener(ShowMaxLifeInfo);
        selectShotDamage.onClick.AddListener(ShowShotDamageInfo);
        selectBombDamage.onClick.AddListener(ShowBombDamageInfo);
        selectMaxBombs.onClick.AddListener(ShowMaxBombsInfo);
        selectBuyLife.onClick.AddListener(ShowBuyLifeInfo);
        selectBuyBombs.onClick.AddListener(ShowBuyBombsInfo);
        closePopup.onClick.AddListener(ClosePopup);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateInfo();
    }
}
