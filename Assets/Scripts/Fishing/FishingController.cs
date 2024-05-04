using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


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

    [SerializeField]
    private GameObject intro;

    [SerializeField]
    private Item day;
    //private int fishingTimes;
    public static FishingController Instance
    {
        get;private set;
    }
    private void Awake()
    {
        Instance = this;
        //PlayerPrefs.DeleteKey(sceneName + "_hasEntered");
        //PlayerPrefs.Save();
        if(day.itemHeld >= 2 && GameActions.jumpPoint == 2)
        {
            SceneManager.LoadScene("Dialogue");
        }
    }

    private string sceneName;

    void CheckFirstTimeEntry(string sceneName)
    {
        if (!PlayerPrefs.HasKey(sceneName + "_hasEntered"))
        {
            // 这是第一次进入这个场景
            Debug.Log("这是您第一次进入 " + sceneName);
            
            intro.SetActive(true);
            // 在这里可以添加你需要执行的代码

            // 设置标志，表示场景已被访问过
            PlayerPrefs.SetInt(sceneName + "_hasEntered", 1);
            PlayerPrefs.Save();
        }
        else
        {
            // 非第一次进入场景
            Debug.Log("欢迎回到 " + sceneName);
        }
    }
    private void Start()
    {
        CheckFirstTimeEntry(sceneName);
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
            day.itemHeld++;

            CurrentSceneInventoryManager.Instance.GetItemList();
        }
    }

}
