using UnityEngine;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class CurrentSceneInventoryManager : MonoBehaviour
{
    public static CurrentSceneInventoryManager Instance {get; private set;}
    public List<Item> CurrentItemList;
    public Transform FishMenu;
    public Transform ResourceMenu;
    public GameObject ItemElement;
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
            switch (item.itemClass)
            {
                case ItemClass.Fish:
                    if (!Templist.ContainsKey(item))
                    {
                        Templist.Add(item, 1);
                    }
                    else
                    {
                        Templist[item]++;
                    }
                    break;
                case ItemClass.Garbage:
                    if (!Templist.ContainsKey(item.TurnToSO))
                    {
                        Templist.Add(item.TurnToSO, 1);
                    }
                    else
                    {
                        Templist[item.TurnToSO]++;
                    }
                    break;
            }
        }
        foreach(var temp in Templist)
        {
            switch (temp.Key.itemClass)
            {
                case ItemClass.Fish:
                    GameObject.Instantiate(ItemElement, FishMenu).GetComponent<ItemElement>().InitItem(temp.Key.itemImage, temp.Value,0.4f);
                    DataItem itm = DataManager.Instance.GetItemClass(temp.Key.name);
                    DataManager.Instance.ChangeCount(itm, temp.Value);
                    if (!itm.hasGet)
                    {
                        DataManager.Instance.ChangeGetState(itm, true);
                        if (temp.Key.isPollted)
                        {
                            continue;
                        }
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
                    GameObject.Instantiate(ItemElement, ResourceMenu).GetComponent<ItemElement>().InitItem(temp.Key.itemImage, temp.Value,0.22f);
                    DataManager.Instance.ChangeCount(DataManager.Instance.GetItemClass(temp.Key.name), temp.Value);
                    break;
            }
        }
        BookList.OnComplete(() => { bookPanel.SetActive(false); });
        BookList.Restart();
    }

}