using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    [Header("Time data")]
    [Tooltip("Time to wait before not being in combat")]
    const float COMBAT_COOLDOWN = 5f;

    [Tooltip("Number of attack per second. Bigger is the attackspeed, smaller the cooldown is")]
    public float attackSpeed = 1.0f;
    [Tooltip("Animation attack delay before applying damage")]
    public float attackDelay = 0.6f;
    //[Tooltip("Character is in combat mode ?")]
    public bool InCombat { get; private set; }

    // time before next attack
    float attackCooldown = 0f;
    // time of the last attack
    float lastAttackTime;
    // character stats
    CharacterStatsBin myStats;

    // CharacterAnimator.OnAttack
    public event System.Action OnAttack;

    private void Start()
    {
        myStats = GetComponent<CharacterStatsBin>();
    }

    private void Update()
    {
        // decrease the cooldown timing
        attackCooldown -= Time.deltaTime;

        // time since my last attack
        if (Time.time - lastAttackTime > COMBAT_COOLDOWN)
        {
            InCombat = false;
        }
        // add check for time since I'm a target of enemy / be hit
    }

    public void Attack(CharacterStatsBin targetStats)
    {
        // if it's time to attack then attack
        if(attackCooldown <= 0f)
        {
            // delaying the animation
            StartCoroutine(DoDamage(targetStats, attackDelay));

            // start the attack animation
            OnAttack?.Invoke();

            // bigger is the attackspeed, smaller the cooldown is
            attackCooldown = 1f / attackSpeed;

            // still in combat
            InCombat = true;
            lastAttackTime = Time.time;
        }
    }

    // Coroutine to delay the damage for the animation
    IEnumerator DoDamage(CharacterStatsBin stats, float delay)
    {
        // wait animation delay
        yield return new WaitForSeconds(delay);
        // apply damage
        stats.TakeDamage(myStats.Damage.GetValue());

        // if target is dead 
        if (stats.CurrentHealth <= 0)
        {
            // then you are no more in combat after 2 secondes
            yield return new WaitForSeconds(2);
            InCombat = true;
        }
    }
}
