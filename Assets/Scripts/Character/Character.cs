using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, ICharacter
{
    protected Health health;
    protected int level;
    public virtual int Level => level;

    public string CharacterName { get; set; }
    public Sprite characterIcon;

    public bool IsAlive { get; set; }
    public bool IsFullLife { get { return health.IsFullLife(); } }

    public CharacterStats characterStats;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        CharacterName = "Character test";
        IsAlive = true;
        health = GetComponent<Health>();
        level = 1;

        health.OnHealthReachedZero += Die;
    }

    public void UpdateStats()
    {
        health.MaxHealth += (int)characterStats.Stamina.Value * 10;
    }

    public void FullHeal()
    {
        health.FullLife();
    }

    public abstract void NotifyHealthChanged();

    public virtual void TakeDamage(int amount)
    {
        health.DecreaseCurrentLife(amount);

        NotifyHealthChanged();
    }

    public virtual void GetHeal(int amount)
    {
        health.IncreaseCurrentLife(amount);

        NotifyHealthChanged();
    }

    public virtual void Die()
    {
        IsAlive = false;
        Debug.Log("Character has died " + transform.name);
    }
}
