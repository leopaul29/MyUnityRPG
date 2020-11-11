using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentSlotNames { Head, Necklace, Shoulders, Cape, Chest, Wrists, Gloves, Belt, Legs, Feet, Rings, Scroll, Weapon, Shield }

// to create an object in the editor
[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    [Header("Equipment type")]
    public EquipmentSlotNames equipSlotName;
    [Space]
    [Header("Flat stats")]
    public int ArmorBonus;
    public int StrengthBonus;
    public int AgilityBonus;
    public int IntelligenceBonus;
    public int StaminaBonus;
    [Space]
    [Header("Percent stats")]
    public float ArmorPercentBonus;
    public float StrengthPercentBonus;
    public float AgilityPercentBonus;
    public float IntelligencePercentBonus;
    public float StaminaPercentBonus;

    public void Awake()
    {
        type = ItemType.Equipment;
    }

    public override void Use()
    {
        base.Use();

        // Equip the item
        EquipmentManager.instance.Equip(this);
    }

    public override ItemObject GetCopy()
    {
        return Instantiate(this);
    }

    public override void Destroy()
    {
        Destroy(this);
    }

    public void Equip(Character c)
    {
        if (ArmorBonus != 0)
            c.characterStats.Armor.AddModifier(new StatModifier(ArmorBonus, StatModType.Flat, this));
        if (StrengthBonus != 0)
            c.characterStats.Strength.AddModifier(new StatModifier(StrengthBonus, StatModType.Flat, this));
        if (AgilityBonus != 0)
            c.characterStats.Agility.AddModifier(new StatModifier(AgilityBonus, StatModType.Flat, this));        
        if (IntelligenceBonus != 0)
            c.characterStats.Intelligence.AddModifier(new StatModifier(IntelligenceBonus, StatModType.Flat, this));
        if (StaminaBonus != 0)
            c.characterStats.Stamina.AddModifier(new StatModifier(StaminaBonus, StatModType.Flat, this));

        if (ArmorPercentBonus != 0)
            c.characterStats.Armor.AddModifier(new StatModifier(ArmorPercentBonus, StatModType.PercentMult, this));
        if (StrengthPercentBonus != 0)
            c.characterStats.Strength.AddModifier(new StatModifier(StrengthPercentBonus, StatModType.PercentMult, this));
        if (AgilityPercentBonus != 0)
            c.characterStats.Agility.AddModifier(new StatModifier(AgilityPercentBonus, StatModType.PercentMult, this));
        if (IntelligencePercentBonus != 0)
            c.characterStats.Intelligence.AddModifier(new StatModifier(IntelligencePercentBonus, StatModType.PercentMult, this));
        if (StaminaPercentBonus != 0)
            c.characterStats.Stamina.AddModifier(new StatModifier(StaminaPercentBonus, StatModType.PercentMult, this));
    }

    public void Unequip(Character c)
    {
        c.characterStats.Armor.RemoveAllModifiersFromSource(this);
        c.characterStats.Strength.RemoveAllModifiersFromSource(this);
        c.characterStats.Agility.RemoveAllModifiersFromSource(this);
        c.characterStats.Intelligence.RemoveAllModifiersFromSource(this);
        c.characterStats.Stamina.RemoveAllModifiersFromSource(this);
    }

    public override string GetItemType()
    {
        return equipSlotName.ToString();
    }

    public override string GetDescription()
    {
        sb.Length = 0;
        AddStat(ArmorBonus, "Armor");
        AddStat(StrengthBonus, "Strength");
        AddStat(AgilityBonus, "Agility");
        AddStat(IntelligenceBonus, "Intelligence");
        AddStat(StaminaBonus, "Stamina");

        AddStat(ArmorPercentBonus, "Armor", isPercent: true);
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