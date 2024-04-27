using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;

public class GameActions : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public Item coin;

    void Awake()
    {
        dialogueRunner.AddCommandHandler<int>("adjustCoin", AdjustCoin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AdjustCoin(int changeValue)
    {
        coin.itemHeld += changeValue;
    }
}
