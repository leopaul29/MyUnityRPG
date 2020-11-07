using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=SH25f3cXBVc
[Serializable]
// to create an object in the editor
[CreateAssetMenu(fileName = "New CharacterStat", menuName = "Stats/CharacterStat")]
public class CharacterStat : ScriptableObject
{
    public float BaseValue;

    public virtual float Value
    {
        get {
            if (isDirty || BaseValue != lastBaseValue)
            {
                lastBaseValue = BaseValue;
                _value = CalculateFinalValue();
                isDirty = false;
            }
            return _value;
        }
    }

    // to know if we need to recalculate the final value
    protected bool isDirty = true;
    protected float _value;
    protected float lastBaseValue = float.MinValue;

    protected readonly List<StatModifier> statModifiers;
    // allow other class to read the statModifiers list
    public readonly ReadOnlyCollection<StatModifier> StatModifiers;

    public CharacterStat()
    {
        statModifiers = new List<StatModifier>();
        // copy StatModifiers as readonly
        StatModifiers = statModifiers.AsReadOnly();
    }

    public CharacterStat(float baseValue) : this()
    {
        BaseValue = baseValue;
    }
    
    // Add a new modifier to the list
    public virtual void AddModifier(StatModifier modifier)
    {
        isDirty = true;
        statModifiers.Add(modifier);
        statModifiers.Sort(CompareModifierOrder);
    }

    // Remove a modifier from the list
    public virtual bool RemoveModifier(StatModifier modifier)
    {
        if (statModifiers.Remove(modifier))
        {
            isDirty = true;
            return true;
        }

        return false;
    }

    public virtual bool RemoveAllModifiersFromSource(object source)
    {
        bool didRemove = false;

        // in normal loop, remove object from last to first object
        for (int i = statModifiers.Count - 1; i >= 0; i--)
        {
            if (statModifiers[i].Source == source)
            {
                isDirty = true;
                didRemove = true;
                statModifiers.RemoveAt(i);
            }
        }

        return didRemove;
    }

    // Get the final value after applying modifiers
    protected virtual float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;

        StatModifier mod = null;

        // the list is sorted by StatModType
        for (int i = 0; i < statModifiers.Count; i++)
        {
            mod = statModifiers[i];

            if (mod.Type == StatModType.Flat)
            {
                finalValue += mod.Value;
            }
            else if (mod.Type == StatModType.PercentAdd)
            {
                // add every PercentAdd value
                sumPercentAdd += mod.Value;

                // if the next statModifier is end of list or another type
                if(i+1 >= statModifiers.Count || statModifiers[i+1].Type != StatModType.PercentAdd)
                {
                    // compute finalValue by sumPercentAdd 
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            }
            else if (mod.Type == StatModType.PercentMult)
            {
                // for adding 10%, we need to multiplicate the finaleValue by 1+0.1 => 1.1 => 110%
                finalValue *= 1 + mod.Value;
            }

            finalValue += statModifiers[i].Value;
        }

        // 12.0001f != 12f
        return (float)Math.Round(finalValue, 4);
    }

    protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        return a.Order - b.Order;
    }
}
