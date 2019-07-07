using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class Enemy : Character, IEnemy
{
    public int ID { get; set; }
    public int Experience { get; set; }

    public string characterName;

    //PlayerFocus playerFocus;
    //Interactable interactable;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        ID = 0;
        Experience = 100;
        CharacterName = characterName;
        IsAlive = true;

        //playerFocus = PlayerManager.instance.PlayerFocus;
        //interactable = GetComponent<Interactable>();
    }
    
    public override void NotifyHealthChanged()
    {
        UIEventHandler.TargetHealthChanged(health.CurrentHealth, health.MaxHealth);
    }

    public void PerformAttack()
    {
        Debug.Log("Enemy.PerformAttack");
    }

    public override void Die()
    {
        base.Die();

        Destroy(gameObject);
    }
}