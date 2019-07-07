using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class NPC : Character
{
    public string characterName;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        CharacterName = characterName;
    }

    public override void NotifyHealthChanged()
    {
        UIEventHandler.TargetHealthChanged(health.CurrentHealth, health.MaxHealth);
    }

    public override void Die()
    {
        base.Die();

        Destroy(gameObject);
    }
}
