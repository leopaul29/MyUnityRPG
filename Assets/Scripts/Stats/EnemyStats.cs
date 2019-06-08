public class EnemyStats : CharacterStats
{
    public override void Die()
    {
        base.Die();

        // Add death animation

        Destroy(gameObject);
    }
}
