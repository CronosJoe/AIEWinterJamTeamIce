using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    float worldTimer;   // how much time has passed sicne the start of the game
    float torchTimer;   // how much time is left before the torch goes out
    // TODO add player controller script to reference if the player is sprinting

    // public TMP_Text torchTimeRemaining;
    public Slider torchRemainingSlider;

    public float torchSpeedMod;     // the modifier that changes how fast the torch goes out

    void Start()
    {
        worldTimer = 0.0f;
        torchTimer = 10.0f;

        torchSpeedMod = 1.0f;
    }

    void Update()
    {
        worldTimer += Time.deltaTime;
        
        // TODO if player is sprinting, adjust torchSpeedMod, else put it back to 1.0f
        torchTimer -= Time.deltaTime * torchSpeedMod;
        torchRemainingSlider.value = torchTimer;
    }
}
