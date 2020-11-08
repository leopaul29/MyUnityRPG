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
        EquipmentManager.instance.onEquipmentChangedUpdateStats += OnEquipmentChanged;
    }

    void OnEquipmentChanged (EquipmentObject newItem, EquipmentObject oldItem)
    {
        if (oldItem != null)
        {
            //Armor.RemoveModifier(oldItem.Armor);
            //Damage.RemoveModifier(oldItem.Damage);

            if (oldItem.GetType() == typeof(EquipmentObject) && ((EquipmentObject)oldItem).equipSlotName == EquipmentSlotNames.Weapon)
            {
                // destroy equipment GameObject
                Destroy(playerHand.transform.GetChild(0).gameObject);
                equippedIWeapon = null;
            }
        }

        if (newItem != null)
        {
            //Armor.AddModifier(newItem.Armor);
            //Damage.AddModifier(newItem.Damage);

            if(newItem.GetType() == typeof(EquipmentObject) && ((EquipmentObject)newItem).equipSlotName == EquipmentSlotNames.Weapon)
            {
                // instanciate Weapon GameObject at playerHand position&rotation
                equippedWeapon = (GameObject)Instantiate(
                    Resources.Load<GameObject>("Weapons/" + newItem.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);
                // make equippedWeapon child of playerHand
                equippedWeapon.transform.SetParent(playerHand.transform);

                equippedIWeapon = equippedWeapon.GetComponent<IWeapon>();
            }
        }
    }

    #region to erased or move !
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (equippedIWeapon != null)
            {
                PerformWeaponAttack();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
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
    #endregion
}
