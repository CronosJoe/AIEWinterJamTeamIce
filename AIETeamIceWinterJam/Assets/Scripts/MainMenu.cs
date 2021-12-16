using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("Buttons")]
    public Button playButton;
    public Button tutorialButton;
    public Button creditsButton;
    public Button quitButton;
    [Header("Labels")]
    public TMP_Text label;
    public string mainLabel;
    public string tutorialLabel;
    public string creditsLabel;
    [Header("Screens")]
    public GameObject main;
    public GameObject tutorial;
    public GameObject credits;

    void Start()
    {
        label.text = mainLabel;
        main.SetActive(true);
        tutorial.SetActive(false);
        credits.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void ToTutorial()
    {
        label.text = tutorialLabel;
        main.SetActive(false);
        tutorial.SetActive(true);
    }
    public void ToCredits()
    {
        label.text = creditsLabel;
        main.SetActive(false);
        credits.SetActive(true);
    }

    public void BackToMenu()
    {
        label.text = mainLabel;
        main.SetActive(true);
        tutorial.SetActive(false);
        credits.SetActive(false);
    }

    // TODO* implement are you sure?

    public void QuitGame()
    {
        Debug.Log("Game Will Close");
        Application.Quit();
    }
}