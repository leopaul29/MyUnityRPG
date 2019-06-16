using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    public Animator animator;

    CharacterCombat combat;
    CharacterStats stats;
    NavMeshAgent navmeshAgent;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        navmeshAgent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        stats = GetComponent<CharacterStats>();

        combat.OnAttack += OnAttack;
        stats.OnHealthReachedZero += OnDie;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        animator.SetFloat("Speed_Percent", navmeshAgent.velocity.magnitude / navmeshAgent.speed, .1f, Time.deltaTime);
    }

    protected virtual void OnAttack()
    {
        animator.SetTrigger("Base_Attack");
    }

    protected virtual void OnSpecialAttack()
    {
        animator.SetTrigger("Special_Attack");
    }

    protected virtual void OnCastSpell()
    {
        animator.SetTrigger("Cast_Spell");
    }

    protected virtual void OnDie()
    {
        animator.SetTrigger("Die");
    }
}
