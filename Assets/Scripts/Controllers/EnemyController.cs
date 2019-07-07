using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    [Tooltip("Will lookfor only Object in Player Layer")]
    public LayerMask aggroLayerMask;
    [Tooltip("looking for target within that range distance")]
    public float detectionRadius = 5.0f;

    public float meleAttackRange = 2.0f;

    // chase and stop chase property
    NavMeshAgent agent;
    Collider[] withinAggroColliders;
    Player player;
    Transform targetTransform;
    Vector3 originPosition;

    // handle patrolling animation
    bool isPatrolling;
    //Animator animator;

    //CharacterCombat combat;
    //CharacterStats stats;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = meleAttackRange;
        originPosition = transform.position;
        isPatrolling = true;

        //animator = GetComponent<Animator>();
        //animator.SetBool("isPatrolling", isPatrolling);        
    }
    
    private void FixedUpdate()
    {
        withinAggroColliders = Physics.OverlapSphere(transform.position, detectionRadius, aggroLayerMask);
        if (withinAggroColliders.Length > 0)
        {
            //Debug.Log("Player in detectionRadius");
            player = withinAggroColliders[0].GetComponent<Player>();
            targetTransform = player.transform;

            ChasePlayer(player);
        } else
        {
            //Debug.Log("Player not in detectionRadius");
            Patrol();
        }
    }

    void ChasePlayer(Player player)
    {
        isPatrolling = false;

        this.player = player;
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            FaceTarget();
            Debug.Log("Call Enemy.ChasePlayer");
            // if method is not invoked yet, then do it once
            if (!IsInvoking("PerformAttack"))
            {
                //InvokeRepeating(method, starting time, everyTime);
                InvokeRepeating("PerformAttack", 0.5f, 0.1f);
            }
        }
        else
        {
            // cancel invoke when to far
            CancelInvoke("PerformAttack");
        }

        // move the enemy to the player direction
        agent.SetDestination(player.transform.position);
    }

    void Patrol()
    {
        //Debug.Log("Call Enemy.Patrol");
        // back to origin position
        if (!isPatrolling)
        {
            Debug.Log("Coming back to origin position");
            agent.SetDestination(originPosition);

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                isPatrolling = true;
            }
        }
        // set animation to patrol
        else
        {
            //Debug.Log("remainingDistance " + agent.remainingDistance);
            //Debug.Log("destination " + agent.destination);
        }
    }

    void PerformAttack()
    {
        Debug.Log("Call Enemy.PerformAttack");
        //launch an EVENT to combat attack !!!!
        //combat.Attack(target.GetComponent<CharacterStats>());
    }

    void FaceTarget()
    {
        // direction of the target
        // When normalized, a vector keeps the same direction but its length is 1.0.
        Vector3 direction = (targetTransform.position - transform.position).normalized;
        // Get the rotation to point that target
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        // Apply the rotation to the enemy
        // Slerp to smoothly interpolate between enemy current rotation and target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 0.5f);
    }

    // Gizmos are used to give visual debugging or setup aids in the Scene view
    private void OnDrawGizmosSelected()
    {
        // draw detection chase player range in red
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        // draw melee attack range in yellow
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, meleAttackRange);
    }
}
