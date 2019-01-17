﻿using UnityEngine;
[CreateAssetMenu(fileName ="New Item", menuName = "Iventory/Item")]

public class Item : ScriptableObject
{
    new public string name = "Name Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        Debug.Log($"Using {name}");
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.RemoveItem(this);
    }
}
        