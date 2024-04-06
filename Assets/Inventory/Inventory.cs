using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bag", menuName = "Inventory/New Bag")]
public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>();
}
