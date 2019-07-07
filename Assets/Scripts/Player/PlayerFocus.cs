using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// need collider on each object you want the player to focus on (see line 44)
[RequireComponent(typeof(BoxCollider))]
public class PlayerFocus : MonoBehaviour
{
    public Interactable focus;

    private float radiusToInteract = 100.0f;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * Set the focus / Interactable target (item, enemy, NPC)
         */
        GetInteraction();
    }

    #region GetInteraction
    void GetInteraction()
    {
        // If we press left mouse
        if (Input.GetMouseButtonDown(0))
        {
            // We create a ray
            Ray interactionRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit interactionInfo;

            // If the ray hit
            if (Physics.Raycast(interactionRay, out interactionInfo, radiusToInteract))
            {
                // Check if we hit an interactable
                // If we did set it as our focus
                GameObject interactedObject = interactionInfo.collider.gameObject;
                if (interactedObject.tag == "Interactable Object")
                {
                    Debug.Log("Interactable interacted");
                    SetFocus(interactedObject.GetComponent<Interactable>());
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // Stop focusing any object
            RemoveFocus();
        }
    }

    // Set our focus to a new focus
    void SetFocus(Interactable newFocus)
    {
        // If our focus has changed
        if (newFocus != focus)
        {
            // Defocus the old one
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;   // Set our new focus
        }

        newFocus.OnFocused(transform);

        UIEventHandler.PlayerFocusChanged();
    }

    // Remove our current focus
    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;

        UIEventHandler.PlayerFocusChanged();
    }
    #endregion
}
