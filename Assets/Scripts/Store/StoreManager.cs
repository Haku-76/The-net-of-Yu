using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreManager : MonoBehaviour
{
    public static StoreManager Instance;
    public Item coin;
    public TextMeshProUGUI coinHave;
    public Inventory playerInventory;

    [Space(10)]
    public Item netLevelOne;
    public Item netLevelTwo;
    public Item netLevelThree;
    public Item shipLevelOne;
    public Item shipLevelTwo;
    public Item shipLevelThree;
    public Item shipLevelFour;

    [Space(10)]
    public TextMeshProUGUI netLevelTwoCost;
    public TextMeshProUGUI netLevelThreeCost;
    public TextMeshProUGUI shipLevelTwoCost;
    public TextMeshProUGUI shipLevelThreeCost;
    public TextMeshProUGUI shipLevelFourCost;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //Initialization();
        Refresh();
    }

    void Update()
    {
        coinHave.text = coin.itemHeld.ToString();
    }

    public void AddCoin(int amount)
    {
        coin.itemHeld += amount;
    }

    public bool SpendCoin(int amount)
    {
        if (coin.itemHeld >= amount)
        {
            coin.itemHeld -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Initialization()
    {
        playerInventory.itemList.Clear();
        playerInventory.itemList.Add(netLevelOne);
        playerInventory.itemList.Add(shipLevelOne);

        netLevelOne.itemHeld = 1;
        shipLevelOne.itemHeld = 1;

        netLevelTwo.cost = "200";
        netLevelTwo.itemHeld = 0;

        netLevelThree.cost = "400";
        netLevelThree.itemHeld = 0;

        shipLevelTwo.cost = "600";
        shipLevelTwo.itemHeld = 0;

        shipLevelThree.cost = "700";
        shipLevelThree.itemHeld = 0;

        shipLevelFour.cost = "900";
        shipLevelFour.itemHeld = 0;
    }

    public void Refresh()
    {
        netLevelTwoCost.text = netLevelTwo.cost;
        netLevelThreeCost.text = netLevelThree.cost;
        shipLevelTwoCost.text = shipLevelTwo.cost;
        shipLevelThreeCost.text = shipLevelThree.cost;
        shipLevelFourCost.text = shipLevelFour.cost;
    }
}
