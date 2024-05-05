using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FactoryManager : MonoBehaviour
{
    public Item coin;
    public int coinGet = 0;
    public Item pollution;
    public int pollutionGet = 0;

    [Space(10)]
    public Item fishOne;
    public Item fishTwo;
    public Item fishThree;
    public Item fishFour;
    public Item fishFive;

    [Space(10)]
    public TextMeshProUGUI coinHave;
    public TextMeshProUGUI fishOnetext;
    public TextMeshProUGUI fishTwotext;
    public TextMeshProUGUI fishThreetext;
    public TextMeshProUGUI fishFourtext;
    public TextMeshProUGUI fishFivetext;

    [Space(10)]
    public int fishOneSell = 0;
    public int fishTwoSell = 0;
    public int fishThreeSell = 0;
    public int fishFourSell = 0;
    public int fishFiveSell = 0;

    [Space(10)]
    public TextMeshProUGUI fishOneSelltext;
    public TextMeshProUGUI fishTwoSelltext;
    public TextMeshProUGUI fishThreeSelltext;
    public TextMeshProUGUI fishFourSelltext;
    public TextMeshProUGUI fishFiveSelltext;

    void Update()
    {
        coinHave.text = coin.itemHeld.ToString();
        Refresh();
        SellShower();
    }

    public void Refresh()
    {
        fishOnetext.text = "拥有：" + fishOne.itemHeld.ToString();
        fishTwotext.text = "拥有：" + fishTwo.itemHeld.ToString();
        fishThreetext.text = "拥有：" + fishThree.itemHeld.ToString();
        fishFourtext.text = "拥有：" + fishFour.itemHeld.ToString();
        fishFivetext.text = "拥有：" + fishFive.itemHeld.ToString();
    }

    public void SellShower()
    {
        fishOneSelltext.text = fishOneSell.ToString();
        fishTwoSelltext.text = fishTwoSell.ToString();
        fishThreeSelltext.text = fishThreeSell.ToString();
        fishFourSelltext.text = fishFourSell.ToString();
        fishFiveSelltext.text = fishFiveSell.ToString();
    }

    public void IncreaseCount(int index)
    {
        switch (index)
        {
            case 1:
                if (fishOneSell < fishOne.itemHeld)
                {
                    fishOneSell++;
                }
                break;
            case 2:
                if (fishTwoSell < fishTwo.itemHeld)
                {
                    fishTwoSell++;
                }
                break;
            case 3:
                if (fishThreeSell < fishThree.itemHeld)
                {
                    fishThreeSell++;
                }
                break;
            case 4:
                if (fishFourSell < fishFour.itemHeld)
                {
                    fishFourSell++;
                }
                break;
            case 5:
                if (fishFiveSell < fishFive.itemHeld)
                {
                    fishFiveSell++;
                }
                break;
        }
    }

    public void DecreaseCount(int index)
    {
        switch (index)
        {
            case 1:
                if (fishOneSell > 0)
                {
                    fishOneSell--;
                }
                break;
            case 2:
                if (fishTwoSell > 0)
                {
                    fishTwoSell--;
                }
                break;
            case 3:
                if (fishThreeSell > 0)
                {
                    fishThreeSell--;
                }
                break;
            case 4:
                if (fishFourSell > 0)
                {
                    fishFourSell--;
                }
                break;
            case 5:
                if (fishFiveSell > 0)
                {
                    fishFiveSell--;
                }
                break;
        }
    }

    public void Seller()
    {
        SoundManager.Instance.PlaySE(SESoundData.SE.Sold);
        coinGet = fishOneSell * int.Parse(fishOne.cost) + fishTwoSell * int.Parse(fishTwo.cost) + fishThreeSell * int.Parse(fishThree.cost) +
                  fishFourSell * int.Parse(fishFour.cost) + fishFiveSell * int.Parse(fishFive.cost);
        coin.itemHeld += coinGet;

        pollutionGet = fishOneSell * fishOne.pollution + fishTwoSell * fishTwo.pollution + fishThreeSell * fishThree.pollution +
                       fishFourSell * fishFour.pollution + fishFiveSell * fishFive.pollution;
        pollution.itemHeld += pollutionGet;

        fishOne.itemHeld -= fishOneSell;
        fishTwo.itemHeld -= fishTwoSell;
        fishThree.itemHeld -= fishThreeSell;
        fishFour.itemHeld -= fishFourSell;
        fishFive.itemHeld -= fishFiveSell;

        fishOneSell = 0;
        fishTwoSell = 0;
        fishThreeSell = 0;
        fishFourSell = 0;
        fishFiveSell = 0;
    }
}
