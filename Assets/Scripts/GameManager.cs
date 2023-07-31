using System.Collections;
using System.Collections.Generic;
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
    public int playerCurrentHealth;

    private void Awake()
    {
        Singleton();
        DontDestroy();
    }

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

    public void Update()
    {
        updateBombs();
    }

    private void updateBombs()
    {
        bombsText.text = "Bombs: " + playerBombs;
    }

    public void UpdatePlayerHealth(int healthChange)
    {
        playerCurrentHealth += healthChange;

        playerCurrentHealth = Mathf.Clamp(playerCurrentHealth, 0, playerMaxHealth);

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        Debug.Log("Player Health: " + playerCurrentHealth);
    }

    
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void getDamage(int damage)
    {
        currentHealth -= damage;

        GameManager.instance.UpdatePlayerHealth(-damage);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            int damageAmount = enemy.damageAmount;
            getDamage(damageAmount);
            Destroy(other.gameObject);
        }
    }
}
