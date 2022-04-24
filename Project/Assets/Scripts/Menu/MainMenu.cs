using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string MainLevelName;

    public void NewGame()
    {

        StartCoroutine(LoadMainSceneAsync());
    }

    public void Quit()
    {
        Application.Quit();
    }


    private IEnumerator LoadMainSceneAsync()
    {
        yield return new WaitForSeconds(.1f);  // necessary for smooth transition
        AsyncOperation mainScene = SceneManager.LoadSceneAsync(MainLevelName);
        while(mainScene.progress < 1)
        {
            Debug.Log(mainScene.progress);
            yield return new WaitForEndOfFrame();
        }

    }
}
