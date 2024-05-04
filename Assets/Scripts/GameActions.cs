using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;
using UnityEngine.SceneManagement;

public class GameActions : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public Item coin;
    private static int coinNum;
    public Item pollution;
    private static int pollutionNum;
    private static int jumpPoint;
    //public GameObject levelLoader;

    void Awake()
    {
        dialogueRunner.AddCommandHandler<int>("adjustCoin", AdjustCoin);
        //levelLoader = GameObject.Find("LevelLoader").gameObject;
    }
    private void Start()
    {
        print("itemHeld" + coin.itemHeld);
    }

    private void AdjustCoin(int changeValue)
    {
        coin.itemHeld += changeValue;
    }

    private void Update()
    {
        coinNum = coin.itemHeld;
        //print("itemHeld" + coin.itemHeld);
        
        //pollutionNum = pollution.itemHeld;
    }

    [YarnCommand("BuyShip")]
    public void BuyShip()
    {
        print("已经买了");
        coin.itemHeld -= 600;
    }

    [YarnFunction("checkCoin")]
    public static int checkCoin()
    {
        print("金钱总额" + coinNum);
        return coinNum;
    }

    [YarnCommand("addPollution")]
    public void pollutionChange(int addNum)
    {
        pollution.itemHeld += addNum;
    }

    [YarnCommand("NextScene")]
    public void NextScene(string sceneName)
    {
        //StartCoroutine(levelLoader.GetComponent<LevelLoader>().LoadLevel(sceneName));
        SceneManager.LoadScene(sceneName);
    }

    [YarnCommand("startNode")]
    public void startNode(string nodeName)
    {
        print("startNode将改为" + nodeName);
        dialogueRunner.startNode = nodeName;
    }

    [YarnFunction("jumpToPoint")]
    public static int JumpPoint()
    {
        return jumpPoint;
    }

    [YarnCommand("setJumpPoint")]
    public void setJumpPoint(int pointNum)
    {
        jumpPoint = pointNum;
    }
}
