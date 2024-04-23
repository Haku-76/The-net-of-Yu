using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreManager : MonoBehaviour
{
    public Item coin;
    public TextMeshProUGUI coinHave;

    void Start()
    {
        
    }

    void Update()
    {
        coinHave.text = coin.itemHeld.ToString();
    }
}
