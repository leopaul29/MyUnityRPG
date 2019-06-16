using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public float lookRadius = 5f;

    // udpate rotation speed ?

    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            // Face the target
            FaceTarget();
        }
    }

    void FaceTarget()
    {
        // direction of the target
        // When normalized, a vector keeps the same direction but its length is 1.0.
        Vector3 direction = (target.position - transform.position).normalized;
        // Get the rotation to point that target
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        // Apply the rotation to the enemy
        // Slerp to smoothly interpolate between enemy current rotation and target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 0.5f);
    }

    // Gizmos are used to give visual debugging or setup aids in the Scene view
    private void OnDrawGizmosSelected()
    {
        // Display the wireframe when selected
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
