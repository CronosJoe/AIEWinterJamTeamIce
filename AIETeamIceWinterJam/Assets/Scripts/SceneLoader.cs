using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
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
}