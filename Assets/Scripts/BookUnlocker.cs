using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookUnlocker : MonoBehaviour
{ 
    public Item unlockItem;
    public GameObject imageBefore;
    public GameObject imageAfter;
    public GameObject introductionBefore;
    public GameObject introductionAfter;
    public TextMeshProUGUI amountHave;
    public TextMeshProUGUI amountNeed;
    public GameObject compositeAfter;
    public GameObject hint;
    public GameObject obtain;
    public GameObject vfx;
    public float displayTime = 3.0f;

    void Update()
    {
        amountHave.text = unlockItem.itemHeld.ToString();
    }

    public void unlock()
    {
        if(imageAfter.activeInHierarchy == false)
        {
            if (int.Parse(amountHave.text) >= int.Parse(amountNeed.text))
            {
                obtain.SetActive(true);
                vfx.SetActive(true);
                imageBefore.SetActive(false);
                imageAfter.SetActive(true);
                introductionBefore.SetActive(false);
                introductionAfter.SetActive(true);
                unlockItem.itemHeld -= int.Parse(amountNeed.text);
                StartCoroutine(DisableAfterTime(obtain, displayTime));
                compositeAfter.SetActive(true);
            }
            else
            {
                hint.SetActive(true);
                StartCoroutine(DisableAfterTime(hint, displayTime));
            }
        }
        
    }

    IEnumerator DisableAfterTime(GameObject objectToDisable, float time)
    {
        yield return new WaitForSeconds(time);
        objectToDisable.SetActive(false);
    }

}
