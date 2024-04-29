using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bag", menuName = "Inventory/New Bag")]
public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>();
    public void AddItem(Item item,int amount)
    {
        if (itemList.Contains(item))
        {
            item.itemHeld += amount;
        }
        else
        {
            itemList.Add(item);
            item.itemHeld = amount;
        }
    }
}
