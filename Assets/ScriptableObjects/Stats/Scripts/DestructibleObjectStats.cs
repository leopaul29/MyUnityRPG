using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DestructibleObjectStats", menuName = "Stats System/DestructibleObjectStats")]
public class DestructibleObjectStats : ScriptableObject
{
    public BaseStat Armor;
    public BaseStat Stamina;
}
