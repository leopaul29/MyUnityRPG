using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IFrameName
{
    void DisplayFrame();
    void UpdateAvatar(Sprite characterIcon);
    void UpdateName(string name);
    void UpdateHealth(int currentHealth, int maxHealth);
    void UpdateMana(int currentMana, int maxMana);
    void UpdateLevel(int level);
}
