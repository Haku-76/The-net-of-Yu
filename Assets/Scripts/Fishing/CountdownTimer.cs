using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float timeLeft; 
    public TextMeshProUGUI countdownText;

    [Space(15)]
    public GameObject CheckoutPage;
    public TextMeshProUGUI fishText;
    public TextMeshProUGUI resourceText;
    public TextMeshProUGUI garbageText;

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (countdownText != null)
            {
                countdownText.text = "剩余时间: " + Mathf.Round(timeLeft).ToString();
            }
        }
        else
        {
            this.GetComponent<CurrentSceneInventoryManager>().PrintInventory(fishText, resourceText, garbageText);
            CheckoutPage.SetActive(true);
        }
    }
}
