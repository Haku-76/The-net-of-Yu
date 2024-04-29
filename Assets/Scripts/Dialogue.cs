using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Dialogue : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    private void Awake()
    {
        dialogueRunner.AddCommandHandler<string>("adjustEmotion", AdjustEmotion);
    }

    private void AdjustEmotion(string changeValue)
    {
        //value.emotion += int.Parse(changeValue);
    }
}
