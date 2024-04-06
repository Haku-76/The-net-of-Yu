using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private StorePurchase purchase;
    [Header("测试用端口：硬币数量")][SerializeField] private int coins;
    [SerializeField] private TextMeshProUGUI coinText;

    private void Start()
    {
        //增加订阅
        if (purchase != null)
        {
            purchase.OnPurchase += coinsChanged;
        }
    }

    //监听，当发生币量变化时
    private void coinsChanged(int newcoins)
    {
        coins = newcoins;
        coinText.text = coins.ToString();
    }

    private void OnDestroy()
    {
        if (purchase != null)
        {
            purchase.OnPurchase -= coinsChanged;
        }
    }
}
