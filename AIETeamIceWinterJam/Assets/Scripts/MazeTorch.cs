using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTorch : MonoBehaviour
{
    public GameObject torch;
    // TODO how are we making the appear torch "lit"? animation controller? sprite 1 and 2? second game object? particle system?
    public bool lit;

    void Start()
    {
        lit = false;
    }

    public void LightTorch()
    {
        // TODO change how the gameobject appears when lit
        // TODO* sound?
        lit = true;
    }
}