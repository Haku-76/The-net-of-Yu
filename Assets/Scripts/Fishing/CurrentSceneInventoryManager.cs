using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class CurrentSceneInventoryManager : MonoBehaviour
{
    private Dictionary<string, Dictionary<string, int>> inventory;

    void Start()
    {
        // ��ʼ���洢�ṹ
        inventory = new Dictionary<string, Dictionary<string, int>>();

        // �����������ʼ��һЩ��������
        AddItem("��", "��1", 1);
        AddItem("��", "��2", 2);
        AddItem("��", "��3", 3);

        AddItem("��Դ", "����", 1);
        AddItem("��Դ", "����", 2);
        AddItem("��Դ", "��", 3);

        AddItem("����", "���ϴ�", 1);
        AddItem("����", "������", 2);
        AddItem("����", "������", 3);

    }

    // �����Ʒ�����ķ���
    public void AddItem(string category, string item, int quantity)
    {
        // ����Ƿ������������
        if (!inventory.ContainsKey(category))
        {
            inventory[category] = new Dictionary<string, int>();
        }

        // ����������Ƿ����������Ʒ
        if (!inventory[category].ContainsKey(item))
        {
            inventory[category][item] = 0;
        }

        // ������Ʒ����
        inventory[category][item] += quantity;
        Debug.Log($"���: {category} - {item}, ����: {inventory[category][item]}");
    }

    // ���ڼ����ض���Ʒ�����ķ���
    public int GetItemQuantity(string category, string item)
    {
        if (inventory.ContainsKey(category) && inventory[category].ContainsKey(item))
        {
            return inventory[category][item];
        }
        return 0;
    }

    // ���ڴ�ӡ��ǰ������Ʒ״̬�ķ���
    public void PrintInventory()
    {
        foreach (var category in inventory)
        {
            Debug.Log($"����: {category.Key}");
            foreach (var item in category.Value)
            {
                Debug.Log($"  ��Ʒ: {item.Key}, ����: {item.Value}");
            }
        }
    }

    public void PrintInventory(TextMeshProUGUI fishText, TextMeshProUGUI resourceText, TextMeshProUGUI garbageText)
    {
        // ��ʼ�����������ַ���
        string fishInfo = "��:\n";
        string resourceInfo = "��Դ:\n";
        string garbageInfo = "����:\n";

        foreach (var category in inventory)
        {
            foreach (var item in category.Value)
            {
                // ������𣬽���Ʒ��Ϣ��ӵ���Ӧ���ַ���
                if (category.Key == "��")
                {
                    fishInfo += $"{item.Key}: {item.Value}\n";
                }
                else if (category.Key == "��Դ")
                {
                    resourceInfo += $"{item.Key}: {item.Value}\n";
                }
                else if (category.Key == "����")
                {
                    garbageInfo += $"{item.Key}: {item.Value}\n";
                }
            }
        }

        // ���ַ��������TextMeshProUGUI����
        fishText.text = fishInfo;
        resourceText.text = resourceInfo;
        garbageText.text = garbageInfo;
    }
}
