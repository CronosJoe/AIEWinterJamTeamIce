using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header ("Leave This Alone")]
    [SerializeField]
    private float worldTimer;       // how much time has passed sicne the start of the game
    int minutesInGame;
    [Header ("You Can Change These")]
    public float torchTimer;        // how much time is left before the torch goes out
    // TODO playerController player;
    public float torchSpeedMod;     // the modifier that changes how fast the torch goes out

    [Header ("Connect To Objects On Canvas")]
    public Slider torchRemainingSlider;     // slider to show the current status of the torch (time remaining without numbers)
    // public TMP_Text torchTimeRemaining;  // timer to show the current status of the torch (time remaining with numbers)
    public TMP_Text timeInGame;

    void Start()
    {
        worldTimer = 0.0f;
        minutesInGame = 0;
    }

    void Update()
    {
        worldTimer += Time.deltaTime;
        if(worldTimer >= 60)
        {
            minutesInGame++;
            worldTimer = 0.0f;
        }

        if(worldTimer < 10)
        {
            timeInGame.text = minutesInGame + ":0" + Mathf.Floor(worldTimer).ToString();
        }
        else
        {
            timeInGame.text = minutesInGame + ":" + Mathf.Floor(worldTimer).ToString();
        }

        // TODO
        // if(player.isSprinting)
        //{
            
        //}
        torchTimer -= Time.deltaTime * torchSpeedMod;
        torchRemainingSlider.value = torchTimer;
        // torchTimeRemaining.text = Mathf.Floor(torchTimer).ToString();

        // TODO if player lights another torch, add time to the torchTimer
    }
}