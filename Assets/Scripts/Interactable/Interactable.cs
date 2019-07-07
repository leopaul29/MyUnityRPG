using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Interactable : MonoBehaviour
{
    // distance between the player and the target to interact
    public float RadiusToInteract = 3.0f;
    // Origin of the interaction
    // its often the Interactable object itself (item, enemy, NPC)
    public Transform interactionTransform;

    // Does the player focus this object
    bool isFocus;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        // This method is mean to be overwritten
        // Debug.Log("Interacting with base class " + transform.name);
    }

    void Update()
    {
        Debug.Log("Interactable0:isFocus="+ isFocus+ "/hasInteracted="+ hasInteracted+ "/Input.GetMouseButtonDown(0)="+ Input.GetMouseButtonDown(0));
        if (isFocus && !hasInteracted && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Interactable1");
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= RadiusToInteract)
            {
                Debug.Log("Interactable2");
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    // Gizmos are used to give visual debugging or setup aids in the Scene view
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }

        // Display the wireframe when selected
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, RadiusToInteract);
    }
}
