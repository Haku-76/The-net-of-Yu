using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    //�������нṹ������б����޸ģ�
    [SerializeField]
    public List<DataItem> dataItems;
    public int polluteValue;
    public int coinCount;
    public int date;
    [SerializeField]
    //��������item����б�Ŀǰȱ��������item�࣬������Ҫ������ӣ�
    private List<Item> allItem;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        LoadGame();
        SaveGame();
    }
    //��ӽṹ��Ԫ��(���������ɸ�,���ڳ�ʼ��)
    public void AddItem(string nam,int num)
    {
        if (num < 0)
        {
            for (int i = 0; i < dataItems.Count; i++)
            {
                if (dataItems[i].name == nam)
                {
                    ChangeCount(dataItems[i], num);
                }
            }
        }
        else
        {
            bool has = false;
            for (int i = 0; i < dataItems.Count; i++)
            {
                if (dataItems[i].name == nam)
                {
                    ChangeCount(dataItems[i], num);
                    has = true;
                }
            }
            if (!has)
            {
                DataItem ite = new DataItem() { name = nam, count = num, hasGet =false };
                dataItems.Add(ite);
            }
        }
    }
    //�ı�������״̬
    public void ChangeGetState(DataItem target,bool get)
    {
        target.hasGet = get;
    }
    //�ı���������
    public void ChangeCount(DataItem target, int num)
    {
        if (num < 0)
        {
            if(-num >= target.count)
            {
                target.count = 0;
            }
            else
            {
                target.count += num;
            }
        }
        else
        {
            target.count += num;
        }
    }
    //������Ϸ��Ŀǰû�е��ã�
    public void SaveGame()
    {
        string filePath = Application.dataPath + "/dataStore" + "/gamedata.json";
        DataItemList dataItemList = new DataItemList();
        dataItemList.items = dataItems;
        string savedata = JsonUtility.ToJson(dataItemList);
        StreamWriter sr= new StreamWriter(filePath);
        sr.Write(savedata);
        sr.Close();
    }
    //������Ϸ���ô��루��ʼ����
    public void LoadGame()
    {
        string filePath = Application.dataPath + "/dataStore"+"/gamedata.json";
        if (File.Exists(filePath))
        {
            StreamReader sr= new StreamReader(filePath);
            string json= sr.ReadToEnd();
            DataItemList p= JsonUtility.FromJson<DataItemList>(json);
            dataItems = p.items;
            sr.Close();
            polluteValue = GetItemClass("��Ⱦ").count;
            coinCount=GetItemClass("���").count;
            date=GetItemClass("ʱ��").count;
        }
        else
        {
            foreach(Item t in allItem)
            {
                AddItem(t.name, 0);
            }
            AddItem("���", 200);
            coinCount = 200;
        }
    }
    //���Ԫ�ص���
    public DataItem GetItemClass(string temp)
    {
        foreach (DataItem t in dataItems)
        {
            if(t.name==temp)
            { return t; }
        }
        return new DataItem();
    }
    //���Ԫ�ص�Item��
    public Item GetItemSO(string temp)
    {
        foreach(Item t in allItem)
        {
            if (t.name==temp)
            {
                return t;
            }
        }
        return null;
    }
}
//���ڴ����������ƣ��������Ƿ��õĽṹ��
[Serializable]
public class DataItem
{
    public string name;
    public int count;
    public bool hasGet;
}
public class DataItemList
{
    public List<DataItem> items=new List<DataItem>();
}