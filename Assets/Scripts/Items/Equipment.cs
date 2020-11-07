using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// to create an object in the editor
[CreateAssetMenu(fileName = "New Equipment", menuName = "Items/Equipment")]
public class Equipment : Item
{
    [Header("Flat stats")]
    public int StrengthBonus;
    public StatModifier AgilityBonus;
    public int IntelligenceBonus;
    public int StaminaBonus;
    [Space]
    [Header("Percent stats")]
    public float StrengthPercentBonus;
    public float AgilityPercentBonus;
    public float IntelligencePercentBonus;
    public float StaminaPercentBonus;
    [Space]
    [Header("Equipment type")]
    public EquipmentSlotNames equipSlotName;  

    public override void Use()
    {
        base.Use();

        // Equip the item
        EquipmentManager.instance.Equip(this);

        // Remove it from the inventory
        RemoveFromInventory();
    }

    public override Item GetCopy()
    {
        return Instantiate(this);
    }

    public override void Destroy()
    {
        Destroy(this);
    }

    public void Equip(Character c)
    {
        if (StrengthBonus != 0)
            c.Strength.AddModifier(new StatModifier(StrengthBonus, StatModType.Flat, this));
        //if (AgilityBonus != 0)
        //c.Agility.AddModifier(new StatModifier(AgilityBonus, StatModType.Flat, this));
        if (AgilityBonus.Value != 0) {
            AgilityBonus.Source = this;
            c.Agility.AddModifier(AgilityBonus);

        }
        if (IntelligenceBonus != 0)
            c.Intelligence.AddModifier(new StatModifier(IntelligenceBonus, StatModType.Flat, this));
        if (StaminaBonus != 0)
            c.Stamina.AddModifier(new StatModifier(StaminaBonus, StatModType.Flat, this));

        if (StrengthPercentBonus != 0)
            c.Strength.AddModifier(new StatModifier(StrengthPercentBonus, StatModType.PercentMult, this));
        if (AgilityPercentBonus != 0)
            c.Agility.AddModifier(new StatModifier(AgilityPercentBonus, StatModType.PercentMult, this));
        if (IntelligencePercentBonus != 0)
            c.Intelligence.AddModifier(new StatModifier(IntelligencePercentBonus, StatModType.PercentMult, this));
        if (StaminaPercentBonus != 0)
            c.Stamina.AddModifier(new StatModifier(StaminaPercentBonus, StatModType.PercentMult, this));
    }

    public void Unequip(Character c)
    {
        c.Strength.RemoveAllModifiersFromSource(this);
        c.Agility.RemoveAllModifiersFromSource(this);
        c.Intelligence.RemoveAllModifiersFromSource(this);
        c.Stamina.RemoveAllModifiersFromSource(this);
    }

    public override string GetItemType()
    {
        return equipSlotName.ToString();
    }

    public override string GetDescription()
    {
        sb.Length = 0;
        AddStat(StrengthBonus, "Strength");
        //AddStat(AgilityBonus, "Agility");
        AddStat(AgilityBonus.Value, "Agility");
        AddStat(IntelligenceBonus, "Intelligence");
        AddStat(StaminaBonus, "Stamina");

        AddStat(StrengthPercentBonus, "Strength", isPercent: true);
        AddStat(AgilityPercentBonus, "Agility", isPercent: true);
        AddStat(IntelligencePercentBonus, "Intelligence", isPercent: true);
        AddStat(StaminaPercentBonus, "Stamina", isPercent: true);

        return sb.ToString();
    }

    private void AddStat(float value, string statName, bool isPercent = false)
    {
        if (value != 0)
        {
            if (sb.Length > 0)
                sb.AppendLine();

            if (value > 0)
                sb.Append("+");

            if (isPercent)
            {
                sb.Append(value * 100);
                sb.Append("% ");
            }
            else
            {
                sb.Append(value);
                sb.Append(" ");
            }
            sb.Append(statName);
        }
    }
}

public enum EquipmentSlotNames { Head, Necklace, Shoulders, Cape, Chest, Wrists, Gloves, Belt, Legs, Feet, Rings, Scroll, Weapon, Shield }