using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // looking for target at distance
    public float lookRadius = 5.0f;
    // stopping distance margin to auto attack
    readonly float margin = 0.2f;
    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;

    // Start is called before the first frame update
    void Start()
    {
        // Main interaction with target
        target = PlayerManager.instance.player.transform;
        // Movement terrain
        agent = GetComponent<NavMeshAgent>();
        // Combat status
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * Enemy in combat mode will move to the target and attack auto
         */
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            // Enemy move to target direction
            agent.SetDestination(target.position);

            // if enemy is at shorter distance than stoppingDistance of the target of at least 0.2f
            if (distance <= agent.stoppingDistance + margin)
            {
                // Attack the target
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if(targetStats != null)
                {
                    combat.Attack(targetStats);
                }

                // Face the target
                FaceTarget();
            }
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
