using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class StorePurchase : MonoBehaviour
{
    public event CoinsChangedDelegate OnPurchase;
    private NetState netState = new NetState();
    [Header("测试用端口：硬币数量")][SerializeField]private int coins  = 150;
    private void Awake()
    {
        
    }
    public void upgradeSpeed()
    {
        int newcoins = coins;
        if (coins >= netState.upgradeSpeedLevelCoins[netState.SpeedLevel])
        {
            newcoins = coins - netState.upgradeSpeedLevelCoins[netState.SpeedLevel];
        }
        else
        {
            print("没有足够的金币");
        }
        coins = newcoins;
        netState.SpeedLevel++;
        OnPurchase?.Invoke(newcoins);
    }
}

public class NetState
{
    public int SpeedLevel = 0;
    public int RangeLevel = 0;
    public int AreaLevel = 0;
    public List<int> upgradeSpeedLevelCoins = new List<int>
    {
        50, 100, 200,
    };
    public List<int> upgradeRangeLevelCoins = new List<int>
    {
        60, 70,110
    };
    public List<int> upgradeAreaLevelCoins = new List<int>
    {
        90,200,210
    };
}

public delegate void CoinsChangedDelegate(int newValue);