using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemElement : MonoBehaviour
{
    public Image ItemImage;
    public TMP_Text AmountText;
    public void InitItem(Sprite sprite,int amount)
    {
        ItemImage.sprite = sprite;
        ItemImage.SetNativeSize();
        AmountText.text=amount.ToString();
    }
}
