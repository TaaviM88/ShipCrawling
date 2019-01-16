using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    public Equipment[] defaultItems;
    //public enum MeshBlendShape { Weapon, KeyItem, Tool };
    /*public SkinnedMeshRenderer targetMesh;
    SkinnedMeshRenderer[] currentMeshes;*/

    private void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] curretEquipment;
    Equipment currentEquip;
    public delegate void OnEquipmenChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmenChanged onEquipmenChanged;
    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        curretEquipment = new Equipment[numSlots];
        EquipDefaultItems();

    }

    public void Equip(Equipment newItem)
    {
        // Find out what slot the item fits in
        int slotIndex = (int)newItem.equipSlot;
        UnEquip(slotIndex);
        Equipment oldItem = UnEquip(slotIndex);

        //An item has been equipped so we trigger the callback
        if (onEquipmenChanged != null)
        {
            onEquipmenChanged.Invoke(newItem, oldItem);
        }
        curretEquipment[slotIndex] = newItem;
        currentEquip = newItem;
        ReturnCurrentEquipment();

        //Tee aseen vaihto tänne jotenkin sitten joskus kun ehdit senkin laiskuri paskiainen

    }

    void EquipDefaultItems()
    {
        if (defaultItems != null)
        {
            foreach (Equipment item in defaultItems)
            {
                Equip(item);
            }
        }
    }

    public Equipment UnEquip(int slotIndex)
    {
        if (curretEquipment[slotIndex] != null)
        {
            /*if (currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }*/
            Equipment oldItem = curretEquipment[slotIndex];
            //SetEquipmentBlendShapes(oldItem, 0);
            inventory.AddItem(oldItem);
            curretEquipment[slotIndex] = null;

            if (onEquipmenChanged != null)
            {
                onEquipmenChanged.Invoke(null, oldItem);
            }
            return oldItem;
        }
        return null;
    }

    public Equipment ReturnCurrentEquipment()
    {
        if (currentEquip != null)
        {
            return currentEquip;
        }
        else
            return null;
    }
}
