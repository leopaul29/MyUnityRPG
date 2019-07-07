public enum StatModType
{
    Flat = 100,           // add number
    PercentAdd = 200,     // add percentAdd (ex: 10 + 10% + 10% = 10 + 20%)
    PercentMult = 300,    // add percentMult (ex: 10 + 10% + 10% = (10 + 10%) + 10%)
}

public class StatModifier
{
    public readonly float Value;
    public readonly StatModType Type;
    public readonly int Order;
    public readonly object Source; // where each modifier come from

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