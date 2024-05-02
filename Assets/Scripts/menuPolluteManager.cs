using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuPolluteManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> levelBg;
    [SerializeField]
    private Item polluteData;
    [SerializeField]
    private Image page6;
    [SerializeField]
    private Sprite polluteSeaRabbit;
    [SerializeField]
    private Image page7;
    [SerializeField]
    private Sprite polluteYellowFish;

    void Start()
    {
        if (polluteData.itemHeld>10&&polluteData.itemHeld<=15)
        {
            page6.sprite = polluteSeaRabbit;
            levelBg[0].SetActive(false);
            levelBg[1].SetActive(true);
        }
        else if (polluteData.itemHeld>15)
        {
            page6.sprite = polluteSeaRabbit;
            page7.sprite = polluteYellowFish;
            levelBg[1].SetActive(false);
            levelBg[2].SetActive(true);
        }
    }
    void Update()
    {
        
    }
}
