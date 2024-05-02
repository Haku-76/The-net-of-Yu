using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class SceneSwitcher : MonoBehaviour
{
    public bool hasBoughtBoat = false;
    public GameObject levelLoader;
    //public DialogueRunner dialogueRunner;

    private void Start()
    {
        levelLoader = GameObject.Find("LevelLoader").gameObject;
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(levelLoader.GetComponent<LevelLoader>().LoadLevel(sceneName));
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
}
