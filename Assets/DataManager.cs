using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    //储存所有结构体类的列表（可修改）
    [SerializeField]
    public List<DataItem> dataItems;
    public int polluteValue;
    public int coinCount;
    public int date;
    [SerializeField]
    //储存所有item类的列表（目前缺少垃圾的item类，如有需要可以添加）
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
    //添加结构体元素(数量可正可负,用于初始化)
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
    //改变物体获得状态
    public void ChangeGetState(DataItem target,bool get)
    {
        target.hasGet = get;
    }
    //改变物体数量
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
    //保存游戏（目前没有调用）
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
    //加载游戏调用代码（初始化）
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
            polluteValue = GetItemClass("污染").count;
            coinCount=GetItemClass("金币").count;
            date=GetItemClass("时间").count;
        }
        else
        {
            foreach(Item t in allItem)
            {
                AddItem(t.name, 0);
            }
            AddItem("金币", 200);
            coinCount = 200;
        }
    }
    //获得元素的类
    public DataItem GetItemClass(string temp)
    {
        foreach (DataItem t in dataItems)
        {
            if(t.name==temp)
            { return t; }
        }
        return new DataItem();
    }
    //获得元素的Item类
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
//用于储存物体名称，数量，是否获得的结构体
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