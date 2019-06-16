using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1.0f;
    private float attackCooldown = 0f;

    public float attackDelay = 0.6f;

    public event System.Action OnAttack;

    CharacterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        // decrease the cooldown timing
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        // if it's time to attack then attack
        if(attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            OnAttack?.Invoke();

            // bigger is the attackspeed, smaller the cooldown is
            attackCooldown = 1f / attackSpeed;
        }
    }

    // Coroutine to delay the damage for the animation
    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.damage.GetValue());
    }
}
