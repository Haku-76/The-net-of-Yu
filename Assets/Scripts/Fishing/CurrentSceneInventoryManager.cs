using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class CurrentSceneInventoryManager : MonoBehaviour
{
    public static CurrentSceneInventoryManager Instance {get; private set;}
    public List<Item> CurrentItemList;
    public Transform FishMenu;
    public Transform GarbageMenu;
    public Transform ResourceMenu;
    public GameObject ItemElement;
    public Inventory FishBag;
    public Inventory GarbageBag;
    public Inventory ResourceBag;
    private void Awake()
    {
        Instance = this;
    }
    public void AddItem(Item item)
    {
        if (item!=null)
        {
            CurrentItemList.Add(item);
        }
    }
    public void GetItemList ()
    {
        Dictionary<Item,int> Templist= new Dictionary<Item,int>();
        foreach (Item item in CurrentItemList)
        {
            if (!Templist.ContainsKey(item))
            {
                Templist.Add(item,1);
            }
            else
            {
                Templist[item]++;
            }
        }
        foreach(var temp in Templist)
        {
            switch (temp.Key.itemClass)
            {
                case ItemClass.Fish:
                    GameObject.Instantiate(ItemElement, FishMenu).GetComponent<ItemElement>().InitItem(temp.Key.itemImage, temp.Value);
                    FishBag.AddItem(temp.Key, temp.Value);
                    break;
                case ItemClass.Resource:
                    GameObject.Instantiate(ItemElement, ResourceMenu).GetComponent<ItemElement>().InitItem(temp.Key.itemImage, temp.Value);
                    ResourceBag.AddItem(temp.Key, temp.Value);
                    break;
                case ItemClass.Garbage:
                    GameObject.Instantiate(ItemElement, GarbageMenu).GetComponent<ItemElement>().InitItem(temp.Key.itemImage, temp.Value);
                    GarbageBag.AddItem(temp.Key, temp.Value);
                    break;
            }
        }
    }

}