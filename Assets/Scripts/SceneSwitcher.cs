using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class SceneSwitcher : MonoBehaviour
{
    public bool hasBoughtBoat = false;
    public GameObject levelLoader;
    //public DialogueRunner dialogueRunner;
    private int timeOfDay = 0;
    //private LevelLoader levelLoader = new LevelLoader();

    private void Awake()
    {
        SoundManager.Instance.VolumChangeBGM(1f);
    }

    private void Start()
    {
        levelLoader = GameObject.Find("LevelLoader").gameObject;
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(levelLoader.GetComponent<LevelLoader>().LoadLevel(sceneName));
        UpdateTime();
    }

    public void StoreScene()
    {
        if (!hasBoughtBoat)
        {
            SceneManager.LoadScene("Dialogue");
        }
        else
        {
            SceneManager.LoadScene("Store");
        }
    }

    public void UpdateTime()
    {
        timeOfDay = (timeOfDay == 0) ? 1 : 0;
    }
}
