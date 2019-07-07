using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerLevel))]
[RequireComponent(typeof(Health))]
public class Player : Character
{
    PlayerLevel playerLevel;

    public override int Level => playerLevel.Level;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //CharacterName = PlayerManager.instance.PlayerName;

        playerLevel = GetComponent<PlayerLevel>();

        NotifyHealthChanged();
        NotifyStatsChanged();
    }

    public void NotifyStatsChanged()
    {
        UIEventHandler.StatsChanged();
    }

    public override void NotifyHealthChanged()
    {
        UIEventHandler.PlayerHealthChanged(health.CurrentHealth, health.MaxHealth);
    }

    private int ApplyArmorReduction(int damage)
    {
        //Debug.Log("Damage: " + damage);
        //Debug.Log("Armor: " + Armor.GetValue());

        //damage -= Armor.GetValue();

        // Make sure damage doesn't go below 0.
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        return damage;
    }

    public override void TakeDamage(int amount)
    {
        // Subtract the armor value
        amount = ApplyArmorReduction(amount);

        base.TakeDamage(amount);
    }
}
