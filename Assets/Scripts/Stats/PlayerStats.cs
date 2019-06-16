using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public GameObject playerHand;
    public GameObject equippedWeapon { get; set; }
    private IWeapon equippedIWeapon;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        // Will call OnEquipmentChanged method when we equip stuff
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged (Equipment newItem, Equipment oldItem)
    {
        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
            
            // destroy equipment GameObject
            Destroy(playerHand.transform.GetChild(0).gameObject);
            equippedIWeapon = null;
        }

        if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);

            // instanciate Weapon GameObject at playerHand position&rotation
            equippedWeapon = (GameObject)Instantiate(
                Resources.Load<GameObject>("Weapons/" + newItem.objectSlug), playerHand.transform.position, playerHand.transform.rotation);
            // make equippedWeapon child of playerHand
            equippedWeapon.transform.SetParent(playerHand.transform);

            equippedIWeapon = equippedWeapon.GetComponent<IWeapon>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (equippedIWeapon != null)
            {
                PerformWeaponAttack();
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (equippedIWeapon != null)
            {
                PerformWeaponSpecialAttack();
            }
        }
    }

    public void PerformWeaponAttack()
    {
        equippedIWeapon.PerformAttack();
    }

    public void PerformWeaponSpecialAttack()
    {
        equippedIWeapon.PerformSpecialAttack();
    }
}
