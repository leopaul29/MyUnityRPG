using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterStats", menuName = "Stats System/CharacterStats")]
public class CharacterStats : ScriptableObject
{
    public BaseStat Armor;
    public BaseStat Strength;
    public BaseStat Agility;
    public BaseStat Intelligence;
    public BaseStat Stamina;
}
