using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class NPC : Interactable
{
    PlayerManager playerManager;

    void Start()
    {
        playerManager = PlayerManager.instance;
    }

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Interacting with NPC");

        // Talk to the player
    }
}
