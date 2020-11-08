using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Tooltip("Character current health amount")]
    public int CurrentHealth;
    [Tooltip("Character maximum health amount")]
    public int MaxHealth;

    public event System.Action OnHealthReachedZero;

    private void Awake()
    {
        // Start with max HP.
        CurrentHealth = MaxHealth;
    }

    public void FullLife()
    {
        CurrentHealth = MaxHealth;
    }

    public bool IsFullLife()
    {
        return CurrentHealth == MaxHealth;
    }

    public void DecreaseCurrentLife(int amount)
    {
        CurrentHealth -= amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        // If we hit 0. Die.
        if (CurrentHealth == 0)
        {
            OnHealthReachedZero?.Invoke();
        }
    }

    public void IncreaseCurrentLife(int amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
    }
}
