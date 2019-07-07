using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    string CharacterName { get; set; }
    bool IsAlive { get; set; }

    void TakeDamage(int amount);
    void GetHeal(int amount);
    void Die();
}
