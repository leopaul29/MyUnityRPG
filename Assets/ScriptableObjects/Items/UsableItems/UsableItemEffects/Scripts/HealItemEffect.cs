﻿using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Heal")]
public class HealItemEffect : UsableItemEffect
{
    public int HealAmount;

    public override bool CanExecuteEffect(UsableItem usableItem, Character character)
    {
        return !character.IsFullLife;
    }

    public override void ExecuteEffect(UsableItem usableItem, Character character)
    {
        character.GetHeal(HealAmount);
    }

    public override string GetDescription()
    {
        return "Heals for " + HealAmount + " health.";
    }
}
