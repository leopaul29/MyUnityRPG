using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats myStats;

    void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }

    public override void Interact()
    {
        base.Interact();

        // How to Player interact with the Enemy object
        // Player attack the enemy for each interaction
        CharacterCombat playerCombat = playerManager.playerCombat;
        if (playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }

        // fouiller le mob when it's dead


    }
}
