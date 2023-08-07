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

    private int money = 1000;
    private int maxLife = 100;
    private int shotDamage = 25;
    private int bombDamage = 100;
    private int maxBombs = 3;

    private void ShowInfoPanel(string title, string description)
    {
        nameUpgradeText.text = title;
        descriptionUpgradeText.text = description;
        selectPanel.SetActive(false);
        infoPanel.SetActive(true);
    }
    private void ClosePopup()
    {
        popup.SetActive(false);
        blockPanel.SetActive(false);
    }
    public void BuyUpgrade()
    {
        // Verificar si tienes suficiente dinero para la compra.
        if (money >= 1000)
        {
            money -= 1000;
            moneyText.text = "Dinero: " + money.ToString();
        }
        else
        {
            Debug.Log("No tienes suficiente dinero para comprar la mejora.");
            popup.SetActive(true);
            blockPanel.SetActive(true);
        }
    }

    public void ShowMaxLifeInfo()
    {
        ShowInfoPanel("Mejorar vida máxima", maxLifeInfo);
    }

    public void ShowShotDamageInfo()
    {
        ShowInfoPanel("Mejorar daño del disparo", shotDamageInfo);
    }

    public void ShowBombDamageInfo()
    {
        ShowInfoPanel("Mejorar daño de bombas", bombDamageInfo);
    }

    public void ShowMaxBombsInfo()
    {
        ShowInfoPanel("Mejorar máximo de bombas", maxBombsInfo);
    }

    public void ShowBuyLifeInfo()
    {
        ShowInfoPanel("Reparar nave", buyLifeInfo);
    }

    public void ShowBuyBombsInfo()
    {
        ShowInfoPanel("Recargar bombas", buyBombsInfo);
    }

    // Start is called before the first frame update
    void Start()
    {
        selectPanel.SetActive(true);
        infoPanel.SetActive(false);
        // TEST
        moneyText.text = "Dinero: " + money.ToString();
        maxLifeText.text = "Vida máxima: " + maxLife.ToString();
        shotDamageText.text = "Daño disparo: " + shotDamage.ToString();
        bombDamageText.text = "Daño bomba: " + bombDamage.ToString();
        maxBombsText.text = "Máx. bombas: " + maxBombs.ToString();
        //buy.interactable = false;
        //buyText.text = "MAX";

        buy.onClick.AddListener(BuyUpgrade);
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

    }
}
