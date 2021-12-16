using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button instructButton;
    public Button creditsButton;
    public Button quitButton;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log(sceneName);
        //SceneManager.LoadScene(sceneName);
    }

    // TODO* implement are you sure?

    public void QuitGame()
    {
        Application.Quit();
    }
}