public class NPCStats : CharacterStats
{
    public override void Start()
    {
        OnHealthReachedZero += Die;
    }

    public void Die()
    {
        // Add death animation
        Destroy(gameObject);
    }
}
