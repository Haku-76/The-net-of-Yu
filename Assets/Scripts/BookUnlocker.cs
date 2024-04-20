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
    public GameObject tip;
    public GameObject vfx1;
    public GameObject vfx2;
    public float vfx1Duration = 0.5f;
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
                vfx1.SetActive(true);
                StartCoroutine(ActivateSecondEffect(vfx1Duration));
                unlockItem.itemHeld -= int.Parse(amountNeed.text);
                StartCoroutine(DisableAfterTime(tip, displayTime));
                compositeAfter.SetActive(true);
            }
            else
            {
                tip.SetActive(true);
                StartCoroutine(DisableAfterTime(tip, displayTime));
            }
        }
        
    }

    IEnumerator ActivateSecondEffect(float delay)
    {
        yield return new WaitForSeconds(delay);
        vfx2.SetActive(true);
        imageBefore.SetActive(false);
        imageAfter.SetActive(true);
        introductionBefore.SetActive(false);
        introductionAfter.SetActive(true);
    }

    IEnumerator DisableAfterTime(GameObject objectToDisable, float time)
    {
        yield return new WaitForSeconds(time);
        objectToDisable.SetActive(false);
    }

}
