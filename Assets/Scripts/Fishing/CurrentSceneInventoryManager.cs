using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class CurrentSceneInventoryManager : MonoBehaviour
{
    public static CurrentSceneInventoryManager Instance {get; private set;}
    private Dictionary<string, Dictionary<string, int>> inventory;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        // 初始化存储结构
        inventory = new Dictionary<string, Dictionary<string, int>>();

        // 可以在这里初始化一些测试数据
    }

    // 添加物品数量的方法
    public void AddItem(string category, string item, int quantity)
    {
        // 检查是否已有这个种类
        if (!inventory.ContainsKey(category))
        {
            inventory[category] = new Dictionary<string, int>();
        }

        // 检查种类下是否已有这个物品
        if (!inventory[category].ContainsKey(item))
        {
            inventory[category][item] = 0;
        }

        // 增加物品数量
        inventory[category][item] += quantity;
        Debug.Log($"获得: {category} - {item}, 数量: {inventory[category][item]}");
    }

    // 用于检索特定物品数量的方法
    public int GetItemQuantity(string category, string item)
    {
        if (inventory.ContainsKey(category) && inventory[category].ContainsKey(item))
        {
            return inventory[category][item];
        }
        return 0;
    }

    // 用于打印当前所有物品状态的方法
    public void PrintInventory()
    {
        foreach (var category in inventory)
        {
            Debug.Log($"种类: {category.Key}");
            foreach (var item in category.Value)
            {
                Debug.Log($"  物品: {item.Key}, 数量: {item.Value}");
            }
        }
    }

    public void PrintInventory(TextMeshProUGUI fishText, TextMeshProUGUI resourceText, TextMeshProUGUI garbageText)
    {
        // 初始化三个类别的字符串
        string fishInfo = "鱼:\n";
        string resourceInfo = "资源:\n";
        string garbageInfo = "垃圾:\n";

        foreach (var category in inventory)
        {
            foreach (var item in category.Value)
            {
                // 根据类别，将物品信息添加到相应的字符串
                if (category.Key == "鱼")
                {
                    fishInfo += $"{item.Key}: {item.Value}\n";
                }
                else if (category.Key == "资源")
                {
                    resourceInfo += $"{item.Key}: {item.Value}\n";
                }
                else if (category.Key == "垃圾")
                {
                    garbageInfo += $"{item.Key}: {item.Value}\n";
                }
            }
        }

        // 将字符串分配给TextMeshProUGUI对象
        fishText.text = fishInfo;
        resourceText.text = resourceInfo;
        garbageText.text = garbageInfo;
    }
}