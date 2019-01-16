using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public GameObject obj;
    public EquipmentSlot equipSlot;
    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        //EquipmentManager.instance.
        RemoveFromInventory();
    }

}
    public enum EquipmentSlot { Weapon, KeyItem}


