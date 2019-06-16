using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : ActionItem
{
    public string[] dialogue;

    public override void Interact()
    {
        DialogueManager.instance.AddNewDialogue("Sign", dialogue);
        Debug.Log("Interacting with Sign Post.");


    }
}
