using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    [Header("Health data")]
    [Tooltip("Player maximum health amount")]
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    [Space]

    [Header("Stats data")]
    public Stat damage;
    public Stat armor;

    [Header("Canvas UI field")]
    public Image currentHealthbar;
    public Text currentHealthText;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    TakeDamage(10);
        //}

        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    Heal(10);
        //}
    }

    public void TakeDamage(int damage)
    {
        damage = HandleArmorReduction(damage);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        UpdateHealthbar();
    }

    private int HandleArmorReduction(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        return damage;
    }

    public virtual void Die()
    {
        // Die in some way
        // This method is meant to be overwritten
        // Death for player and enemy
        Debug.Log(transform.name + " died.");
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        Debug.Log(transform.name + " takes " + heal + " heal.");

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHealthbar();
    }

    private void UpdateHealthbar()
    {
        // convert value to float to get health pourcent value
        float ratio = (float)currentHealth / (float)maxHealth;
        if(currentHealthbar != null && currentHealthText != null)
        {
            currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
            currentHealthText.text = (ratio * 100).ToString();
        }
    }
}
