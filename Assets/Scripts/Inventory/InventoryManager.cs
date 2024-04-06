using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    //public Inventory myBag;
    //public GameObject slotGrid;

    public Inventory fishBag;
    public GameObject fishSlotGrid;
    public Inventory toolBag;
    public GameObject toolSlotGrid;
    public Inventory resourceBag;
    public GameObject resourceSlotGrid;
    public Inventory rubbishBag;
    public GameObject rubbishSlotGrid;

    [Space(10)]
    public Slot slotPrefab;
    public TextMeshProUGUI itemInformation;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    private void OnEnable()
    {
        //RefreshItem();
        RefreshAllBags();
        instance.itemInformation.text = "";
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInformation.text = itemDescription;
    }

    public static void CreateNewItem(Item item, Inventory bag, GameObject grid)
    {
        Slot newItem = Instantiate(instance.slotPrefab, grid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(grid.transform);

        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotName.text = item.itemName;
        newItem.slotAmount.text = item.itemHeld.ToString();
    }

    //public static void CreateNewItem(Item item)
    //{
    //    Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
    //    newItem.gameObject.transform.SetParent(instance.slotGrid.transform);

    //    newItem.slotItem = item;
    //    newItem.slotImage.sprite = item.itemImage;
    //    newItem.slotNumber.text = item.itemHeld.ToString();
    //}

    public static void RefreshBag(Inventory bag, GameObject grid)
    {
        for (int i = 0; i < grid.transform.childCount; i++)
        {
            Destroy(grid.transform.GetChild(i).gameObject);
        }

        foreach (Item item in bag.itemList)
        {
            CreateNewItem(item, bag, grid);
        }
    }

    public static void RefreshAllBags()
    {
        RefreshBag(instance.fishBag, instance.fishSlotGrid);
        RefreshBag(instance.toolBag, instance.toolSlotGrid);
        RefreshBag(instance.resourceBag, instance.resourceSlotGrid);
        RefreshBag(instance.rubbishBag, instance.rubbishSlotGrid);
    }

    //public static void RefreshItem()
    //{
    //    for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
    //    {
    //        if (instance.slotGrid.transform.childCount == 0)
    //        {
    //            break;
    //        }
    //        Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
    //    }

    //    for (int i = 0; i < instance.myBag.itemList.Count; i++)
    //    {
    //        CreateNewItem(instance.myBag.itemList[i]);
    //    }
    //}
}
