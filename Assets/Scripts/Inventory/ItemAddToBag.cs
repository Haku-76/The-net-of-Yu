using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAddToBag : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(this.gameObject);
        }
    }

    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            playerInventory.itemList.Add(thisItem);
            thisItem.itemHeld += 1;
        }
        else
        {
            thisItem.itemHeld += 1;
        }

        InventoryManager.RefreshAllBags();
        //InventoryManager.RefreshItem();
    }
}
