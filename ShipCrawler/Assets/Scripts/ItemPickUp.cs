using System.Collections;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    
    private void PickUp()
    {
        Journal.Instance.Log($"Picking up { item.name}");

        bool wasPickedUP = Inventory.instance.AddItem(item);

        if (wasPickedUP)
            Destroy(gameObject);
    }
}
