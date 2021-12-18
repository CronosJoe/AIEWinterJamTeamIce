using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public float lightRange;
    public float lightRangeMax;
    public Light light;
    public float lightSpeed;

    [Header("Buttons")]
    public Button playButton;
    public Button tutorialButton;
    public Button creditsButton;
    public Button quitButton;
    [Header("Labels")]
    public TMP_Text label;
    public string mainLabel;
    public GameObject mainLabelImg;
    public string tutorialLabel;
    public string creditsLabel;
    public string winLabel;
    public string loseLabel;
    [Header("Screens")]
    public GameObject main;
    public GameObject tutorial;
    public GameObject credits;
    public GameObject win;
    public GameObject lose;

    public SceneLoader sceneLoader;
    public TMP_Text winScore;
    public TMP_Text lastTimeText;

    void Start()
    {
        light.range = 0;
        lightRange = 0;
        label.text = mainLabel;
        main.SetActive(true);
        tutorial.SetActive(false);
        mainLabelImg.SetActive(true);

        if (sceneLoader.CheckGameWon())
        {
            win.SetActive(true);
            label.text = winLabel;
            main.SetActive(false);
            winScore.text = "You won the game in " + PlayerPrefs.GetString("WorldTime") + " seconds.";
            lastTimeText.text = PlayerPrefs.GetString("LastTime");
        }
        else
        {
            win.SetActive(false);
        }

        if (sceneLoader.CheckGameLost())
        {
            lose.SetActive(true);
            label.text = loseLabel;
            main.SetActive(false);
        }
        else
        {
            lose.SetActive(false);
        }
    }

    public void Update()
    {
        lightRange += Time.deltaTime * lightSpeed;
        if(lightRange > lightRangeMax)
        {
            lightRange = lightRangeMax;
        }
        light.range = lightRange;
    }

    public void ToTutorial()
    {
        label.text = tutorialLabel;
        main.SetActive(false);
        tutorial.SetActive(true);
        mainLabelImg.SetActive(false);
    }
    public void ToCredits()
    {
        label.text = creditsLabel;
        main.SetActive(false);
        credits.SetActive(true);
        mainLabelImg.SetActive(false);
    }

    public void BackToMenu()
    {
        label.text = mainLabel;
        main.SetActive(true);
        tutorial.SetActive(false);
        credits.SetActive(false);
        mainLabelImg.SetActive(true);
    }

    // TODO* implement are you sure?

    public void QuitGame()
    {
        Debug.Log("Game Will Close");
        Application.Quit();
    }
}