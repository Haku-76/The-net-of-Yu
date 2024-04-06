using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private StorePurchase purchase;
    [Header("�����ö˿ڣ�Ӳ������")][SerializeField] private int coins;
    [SerializeField] private TextMeshProUGUI coinText;

    private void Start()
    {
        //���Ӷ���
        if (purchase != null)
        {
            purchase.OnPurchase += coinsChanged;
        }
    }

    //�����������������仯ʱ
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
