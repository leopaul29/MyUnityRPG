﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy : ICharacter
{
    int ID { get; set; }
    int Experience { get; set; }
    
    void PerformAttack();
}
