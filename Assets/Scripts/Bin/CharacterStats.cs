using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterStats: MonoBehaviour
{
    [Tooltip("Player current health amount")]
    public int CurrentHealth;
    [Tooltip("Player maximum health amount")]
    public int MaxHealth;

    [Header("Stats data")]
    [SerializeField]
    private List<Stat> stats = new List<Stat>();

    public Stat Stamina { get => GetStat(StatTypeNames.Stamina); }
    public Stat Damage { get => GetStat(StatTypeNames.Damage); }
    public Stat Armor { get => GetStat(StatTypeNames.Armor); }
    public Stat AttackSpeed { get => GetStat(StatTypeNames.AttackSpeed); }

    public bool IsFullLife { get { return CurrentHealth == MaxHealth; } }

    public event System.Action OnHealthReachedZero;

    void Awake()
    {
        // init Stat charachter list
        stats = new List<Stat>() {
            new Stat(StatTypeNames.Stamina, 0),
            new Stat(StatTypeNames.Damage, 0),
            new Stat(StatTypeNames.Armor, 0),
            new Stat(StatTypeNames.AttackSpeed, 0)
        };

        ComputeStats();

        // Start with max HP.
        CurrentHealth = MaxHealth;
    }

    public virtual void Start()
    {
        // to override

        ComputeStats();

        // Start with max HP.
        CurrentHealth = MaxHealth;
    }

    public Stat GetStat(StatTypeNames statTypeName)
    {
        return this.stats.Find(x => x.StatTypeNames == statTypeName);
    }

    public void ComputeStats()
    {
        MaxHealth = ComputeMaxHealthValue();
    }

    private int ComputeMaxHealthValue()
    {
        return MaxHealth + 10 * Stamina.GetValue();
    }

    // compute other Values

    public void TakeDamage(int damage)
    {
        // Subtract the armor value
        damage = ApplyArmorReduction(damage);

        CurrentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        // If we hit 0. Die.
        if (CurrentHealth == 0)
        {
            OnHealthReachedZero?.Invoke();
        }
    }

    private int ApplyArmorReduction(int damage)
    {
        //Debug.Log("Damage: " + damage);
        //Debug.Log("Armor: " + Armor.GetValue());
        damage -= Armor.GetValue();
        // Make sure damage doesn't go below 0.
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        return damage;
    }

    public void Heal(int heal)
    {
        CurrentHealth += heal;
        Debug.Log(transform.name + " takes " + heal + " heal.");
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
    }
}
