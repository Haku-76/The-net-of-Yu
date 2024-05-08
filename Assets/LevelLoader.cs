using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LoadLevel(string sceneName)
    {
        //SoundManager.Instance.VolumChangeBGM(0f);
        SoundManager.Instance.PlaySE(SESoundData.SE.Button);
        
        this.GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
