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
    int minutesInGame;              // how many minutes have passed since the start of the game, used only for displaying time
    [Header ("You Can Change These")]
    public float torchTimer;        // how much time is left before the torch goes out
    float torchSpeedMod;            // the modifier that changes how fast the torch goes out
    public float torchSpeedNormal;  // the modifier for the torch's speed when the player is not sprinting
    public float torchSpeedSprint;  // the modifier for the torch's speed when the player is sprinting

    [Header ("Connect To Objects In Unity Scene")]
    public PlayerMotor playerMotor;     // connects this script to the player in the scene
    public Slider torchRemainingSlider; // slider to show the current status of the torch (time remaining without numbers)
    // public TMP_Text torchTimeRemaining; // timer to show the current status of the torch (time remaining with numbers)
    // public TMP_Text timeInGame;

    void Start()
    {
        worldTimer = 0.0f;                  // set the world timer to 0 at the start of the game
        minutesInGame = 0;                  // set the number of minutes since the start of the game to 0
        torchSpeedMod = torchSpeedNormal;   // make sure that the torch's burning speed is at the normal speed to start
    }

    void Update()
    {
        worldTimer += Time.deltaTime;   // tick the world timer up
        if(worldTimer >= 60)            // when a minute has passed, increase the counter for minutes and set seconds back to 0
        {
            minutesInGame++;
            worldTimer = 0.0f;
        }

        //if(worldTimer < 10)           // for display, this section sets the time display to minutes:seconds, and puts a 0 in front of the seconds if it is less than 10
        //{
        //    timeInGame.text = minutesInGame + ":0" + Mathf.Floor(worldTimer).ToString();
        //}
        //else
        //{
        //    timeInGame.text = minutesInGame + ":" + Mathf.Floor(worldTimer).ToString();
        //}

        if(playerMotor.isSprinting)          // if the player is sprinting, change the torch burning speed to the sprinting burn speed
        {
            torchSpeedMod = torchSpeedSprint;
        }
        else
        {
            torchSpeedMod = torchSpeedNormal;   // if the player is not sprinting, change the torch bruning speed back to nromal
        }
        torchTimer -= Time.deltaTime * torchSpeedMod;
        torchRemainingSlider.value = torchTimer;    // displays the time left for the torch on a slider
        // torchTimeRemaining.text = Mathf.Floor(torchTimer).ToString();    // displays the time left for the torch with numbers

        // TODO if player lights another torch, add time to the torchTimer and to a counter to check how many have been lit

        if(torchTimer <= 0)
        {
            // TODO adjust later, either add pop-up or a scene
            Debug.Log("Game Over");
        }
    }
}