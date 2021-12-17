using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static bool gameWon;
    public static bool gameLost;

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeScenebyIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Randomizer()
    {
        ChangeScenebyIndex(Random.Range(1, 3));
    }
    public void GameWon()
    {
        gameWon = true;
        gameLost = false;
    }

    public bool CheckGameWon()
    {
        return gameWon;
    }

    public void GameLose()
    {
        gameLost = true;
        gameWon = false;
    }

    public bool CheckGameLost()
    {
        return gameLost;
    }
}
