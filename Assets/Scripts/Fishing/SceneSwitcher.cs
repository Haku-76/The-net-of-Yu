using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class SceneSwitcher : MonoBehaviour
{
    public bool hasBoughtBoat = false;
    //public DialogueRunner dialogueRunner;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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
