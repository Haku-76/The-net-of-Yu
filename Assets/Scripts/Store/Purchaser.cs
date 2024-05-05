using UnityEngine;
using System.Collections.Generic;

public class Purchaser : MonoBehaviour
{
    public StoreManager storeManager;
    public Inventory playerInventory;
    public List<Item> itemForSale;

    public void BuyItem(Item item)
    {      
        int cost = int.Parse(item.cost);

        if (StoreManager.Instance.SpendCoin(cost))
        {
            Debug.Log("Purchased: " + item.name);
            if (!playerInventory.itemList.Contains(item) && item.cost != "已拥有")
            {
                SoundManager.Instance.PlaySE(SESoundData.SE.Sold);
                playerInventory.itemList.Add(item);
                item.itemHeld += 1;
                item.cost = "已拥有";
                this.GetComponent<StoreManager>().Refresh();
            }
        }
        else
        {
            Debug.Log("Not enough gold");
        }
    }
}
