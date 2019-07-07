using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixinStatBoost : ItemMixin
{
    public Stat stat = new Stat(StatTypeNames.Damage, 10);

    public override void Use()
    {
        Debug.Log("Boosting " + stat.ToString());
    }
}
