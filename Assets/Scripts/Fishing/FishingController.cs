using UnityEngine;
using TMPro;


public class FishingController : MonoBehaviour
{
    public float timeLeft; 
    public TextMeshProUGUI countdownText;
    [Space(15)]
    public GameObject CheckoutPage;
    private bool gameover=false;
    [SerializeField]
    private SpriteRenderer bg;
    [SerializeField]
    private Sprite pollutedBg;
    [SerializeField]
    private Item polluteData;
    public static FishingController Instance
    {
        get;private set;
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (polluteData.itemHeld>10)
        {
            bg.sprite = pollutedBg;
        }
    }
    private void Update()
    {
        CountDown();
    }
    public bool isGameOver()
    {
        return gameover;
    }
    public void CountDown()
    {
        if (gameover)
        {
            return;
        }
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
            gameover = true;
            CheckoutPage.SetActive(true);
            CurrentSceneInventoryManager.Instance.GetItemList();
        }
    }

}
