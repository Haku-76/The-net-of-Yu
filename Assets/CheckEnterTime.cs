using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnterTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("É¾³ý" + PlayerPrefs.HasKey("_hasEntered"));
        PlayerPrefs.DeleteKey("_hasEntered");
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
