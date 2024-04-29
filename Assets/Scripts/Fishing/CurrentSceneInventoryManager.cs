﻿using UnityEngine;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

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
    private Sequence BookList;
    public GameObject bookElement;
    [SerializeField]
    private GameObject bookPanel;
    private void Awake()
    {
        Instance = this;
        BookList = DOTween.Sequence();
        BookList.Pause();
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
        bookPanel.SetActive(true) ;
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
                    if (!temp.Key.hasGet)
                    {
                        temp.Key.hasGet = true;
                        GameObject go=Instantiate(bookElement, bookPanel.transform);
                        go.GetComponent<Image>().sprite= temp.Key.bookSpr;
                        go.transform.localScale = Vector3.zero;
                        BookList.Append(go.transform.DOScale(Vector3.one, 0.5f).OnComplete(() => 
                    {
                            BookList.Pause(); 
                            go.GetComponent<Button>().onClick.AddListener(() =>
                            {
                            BookList.Play();
                            go.GetComponent<Button>().enabled = false;
                            }); 
                    }));
                        
                        BookList.Append(go.transform.DOScale(Vector3.zero, 0.3f).OnComplete(()=> { Destroy(go); }));
                    }
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
        BookList.OnComplete(() => { bookPanel.SetActive(false); });
        BookList.Restart();
    }

}