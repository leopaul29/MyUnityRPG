﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour
{
    CharacterStats stats;

    // Start is called before the first frame update
    void Start()
    {
        //stats = PlayerManager.instance.PlayerStats;
    }

    public void ConsumeItem(ItemObject item)
    {
        GameObject itemToSpawn = Instantiate(Resources.Load<GameObject>("Consumables/" + item.ObjectSlug));
        //if (item.ItemModifier)
        //{
        //    itemToSpawn.GetComponent<IConsumable>().Consume(stats);
        //}
        //else
        //    itemToSpawn.GetComponent<IConsumable>().Consume();
    }
}
