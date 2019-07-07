using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyInteraction : Interactable
{
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Interacting with EnemyInteraction " + transform.name);

        // fouiller le mob when it's dead
    }
}
