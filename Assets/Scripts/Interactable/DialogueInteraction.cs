using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteraction : Interactable
{
    public string[] dialogue;

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Interacting with NPC");

        // Talk to the player
        DialogueManager.instance.AddNewDialogue(name, dialogue);
    }
}
