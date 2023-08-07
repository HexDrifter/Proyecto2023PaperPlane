using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    [Header("Player Settings")]
    public GameObject player;
    public int playerMaxHealth = 100;
    public int playerBombs;
    public int money;
    private int playerCurrentHealth;

    [Header("UI Elements")]
    public int damageAmount = 25;
    public TextMeshProUGUI moneyText;

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        UpdateHealthUI();
    }

    public void Update()
    {
    }

    public void UpdatePlayerHealth(int healthChange)
    {
        playerCurrentHealth += healthChange;
        playerCurrentHealth = Mathf.Clamp(playerCurrentHealth, 0, playerMaxHealth);
        UpdateHealthUI();

        if (playerCurrentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthUI()
    {
        Debug.Log("Player Health: " + playerCurrentHealth);
    }

    public void GetDamage(int damage)
    {
        playerCurrentHealth -= damage;
        GameManager.Instance.UpdatePlayerHealth(-damage);

        if (playerCurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("Shop");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            int damageAmount = enemy.damageAmount;
            GetDamage(damageAmount);
            Destroy(other.gameObject);
        }
    }
}
