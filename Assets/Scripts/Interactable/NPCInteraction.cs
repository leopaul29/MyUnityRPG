using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPC))]
public class NPCInteraction : Interactable
{
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Interacting with NPCInteraction " + transform.name);
    }
}
