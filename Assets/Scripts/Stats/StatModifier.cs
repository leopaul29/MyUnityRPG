using UnityEngine;

public enum StatModType
{
    Flat = 100,           // add number
    PercentAdd = 200,     // add percentAdd (ex: 10 + 10% + 10% = 10 + 20%)
    PercentMult = 300,    // add percentMult (ex: 10 + 10% + 10% = (10 + 10%) + 10%)
}

// to create an object in the editor
[CreateAssetMenu(fileName = "New StatModifier", menuName = "Stats/StatModifier")]
public class StatModifier : ScriptableObject
{
    public float Value;
    public StatModType Type;
    public int Order;
    public object Source; // where each modifier come from

    public StatModifier(float value, StatModType type, int order, object source)
    {
        Value = value;
        Type = type;
        Order = order;
        Source = source;
    }

    public StatModifier(float value, StatModType type) : this(value, type, (int)type) { }

    public StatModifier(float value, StatModType type, int order) : this(value, type, order, null) { }

    public StatModifier(float value, StatModType type, object source) : this(value, type, (int)type, source) { }
}