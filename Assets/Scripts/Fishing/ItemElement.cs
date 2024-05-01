using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemElement : MonoBehaviour
{
    public Image ItemImage;
    public TMP_Text AmountText;
    public void InitItem(Sprite sprite,int amount,float size=0.4f)
    {
        ItemImage.sprite = sprite;
        ItemImage.SetNativeSize();
        AmountText.text=amount.ToString();
        ItemImage.transform.localScale = new Vector3(size, size, size);
    }
}
