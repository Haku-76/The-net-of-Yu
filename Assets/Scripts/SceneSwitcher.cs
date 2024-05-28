using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher Instance { get; private set; }
    public Item hasBoughtBoat;
    public GameObject levelLoader;
    //public DialogueRunner dialogueRunner;
    private int timeOfDay = 0;
    //private LevelLoader levelLoader = new LevelLoader();

    private void Awake()
    {
    }

    private void Start()
    {
        SoundManager.Instance.VolumChangeBGM(1f);
        levelLoader = GameObject.Find("LevelLoader").gameObject;
    }
    public void LoadScene(string sceneName)
    {
        if(levelLoader != null)
        {
            StartCoroutine(levelLoader.GetComponent<LevelLoader>().LoadLevel(sceneName));
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
        UpdateTime();
    }

    public void StoreScene()
    {
        if (hasBoughtBoat.itemHeld == 0)
        {
            SceneManager.LoadScene("Dialogue");
        }
        else
        {
            SceneManager.LoadScene("Store");
        }
    }

    public void StartFishingSceneBack()
    {
        
    }


    public void FishingSceneBack()
    {

        FishingController.Instance.Checkout();
    }

    public void UpdateTime()
    {
        timeOfDay = (timeOfDay == 0) ? 1 : 0;
    }
}
