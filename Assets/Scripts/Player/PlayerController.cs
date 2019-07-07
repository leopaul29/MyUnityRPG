using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;

    public Interactable focus;

    // attack range
    public float radius = 3.0f;
    
    CharacterCombat combat;
    //bool isAutoAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * Set the focus / Interactable target (item, enemy, NPC)
         */
        GetInteraction();

        /*
         * Auto-attack 
         */
        //if (Input.GetButtonDown("Auto-Attack"))
        //{
        //    isAutoAttack = !isAutoAttack;
        //}
        //if (Input.GetMouseButton(1))
        //{
        //    isAutoAttack = true;
        //}
        if (focus != null && focus.GetType() == typeof(Enemy))
        {
            AutoAttack();
        }
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
            if (Physics.Raycast(interactionRay, out interactionInfo, 100))
            {
                // Check if we hit an interactable
                // If we did set it as our focus
                GameObject interactedObject = interactionInfo.collider.gameObject;
                if (interactedObject.tag == "Interactable Object")
                {
                    Debug.Log("Interactable interacted");
                    SetFocus(interactedObject.GetComponent<Interactable>());
                }
                else
                {
                    // Stop focusing any object
                    RemoveFocus();
                }
            }
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
    }

    // Remove our current focus
    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
    }
    #endregion

    // move to combat !!!
    void AutoAttack()
    {
        float distance = Vector3.Distance(focus.transform.position, transform.position);

        if (distance <= radius)
        {
            // Attack the target
            CharacterStats targetStats = focus.GetComponent<CharacterStats>();
            if (targetStats != null)
            {

                //InvokeRepeating("PerformAttack", 1, PlayerManager.instance.PlayerStats.AttackSpeed.GetValue());
                combat.Attack(targetStats);
            }
            /*else
            {
                CancelInvoke();
            }*/
        }
    }

    void PerformAttack()
    {
        Debug.Log("Call Player PerformAttack");
        if (focus != null)
        {
            CharacterStats targetStats = focus.GetComponent<CharacterStats>();
            combat.Attack(targetStats);
        }
    }

}
