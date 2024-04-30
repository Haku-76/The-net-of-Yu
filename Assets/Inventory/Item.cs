using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]

public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int itemHeld;
    [TextArea]
    public string itemInfo;

    public int pollution;

    public string cost;
    public float range;
    public float efficiency;
    public float velocity;

    public bool hasGet;
    public ItemClass itemClass;
    public Sprite bookSpr;
    public Item TurnToSO;
    public int needPolluteValue;
    public GameObject pullteFish;
    public bool isPollted;
}
public enum ItemClass
{
    Fish,
    Garbage,
    Resource
}