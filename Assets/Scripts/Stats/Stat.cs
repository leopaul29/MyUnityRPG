using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We want Unity to serialize this class and see the fields in the inspector
[System.Serializable]
public class Stat
{
    [SerializeField] // private attributes but available in the editor
    private int baseValue;

    // Will cumulate all equiments stat value for a uniq stat (eg:armor)
    private List<int> modifiers = new List<int>();

    // Get the final value after applying modifiers
    public int GetValue()
    {
        int finalValue = baseValue;
        // foreach modifiers we add the value on finalValue
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }

    public void AddModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }
}
