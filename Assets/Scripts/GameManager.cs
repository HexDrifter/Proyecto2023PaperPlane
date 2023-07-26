using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Player;
    public int playerMaxHealth;
    public int playerBombs;
    public int money;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI bombsText;


    private void Awake()
    {
        Singleton();
        DontDestroy();
    }
    #region
    private void DontDestroy()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    #endregion

    public void Update()
    {
        updateBombs();
    }

    private void updateBombs()
    {
        
        bombsText.text = "Bombs: "+playerBombs;
    }
}
