using System.Collections.Generic;
using UnityEngine;

// We want Unity to serialize this class and see the fields in the inspector
[System.Serializable]
public class Stat
{
    public StatTypeNames StatTypeNames;
    public int BaseValue;

    // Will cumulate all equiments stat value for a uniq stat (eg:armor)
    private List<int> modifiers = new List<int>();

    public Stat(StatTypeNames statType, int baseValue)
    {
        this.StatTypeNames = statType;
        this.BaseValue = baseValue;
    }

    // Get the final value after applying modifiers
    public int GetValue()
    {
        int finalValue = BaseValue;
        // foreach modifiers we add the value on finalValue
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }

    // Add a new modifier to the list
    public void AddModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }

    // Remove a modifier from the list
    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }
}

public enum StatTypeNames { Stamina, Damage, Armor, AttackSpeed }
