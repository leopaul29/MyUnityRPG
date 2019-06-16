using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public int currentHealth { get; private set; }

    [Header("Stats data")]
    [Tooltip("Player maximum health amount")]
    public Stat maxHealth;
    public Stat damage;
    public Stat armor;

    public event System.Action OnHealthReachedZero;

    void Awake()
    {
        // Start with max HP.
        currentHealth = maxHealth.GetValue();
    }

    public virtual void Start()
    {

    }

    public void TakeDamage(int damage)
    {
        // Subtract the armor value
        damage = ApplyArmorReduction(damage);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth.GetValue());

        // If we hit 0. Die.
        if (currentHealth == 0)
        {
            OnHealthReachedZero?.Invoke();
        }
    }

    private int ApplyArmorReduction(int damage)
    {
        damage -= armor.GetValue();
        // Make sure damage doesn't go below 0.
        damage = Mathf.Clamp(damage, 1, int.MaxValue);
        return damage;
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        Debug.Log(transform.name + " takes " + heal + " heal.");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth.GetValue());
    }
}
