using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header ("Leave These Alone")]
    [SerializeField]
    static public float worldTimer;        // how much time has passed sicne the start of the game
    [SerializeField]
    private float torchTimer;       // how much time is left before the torch goes out
    [SerializeField]
    int torchesLit;                 // how many torches have been lit so far
    string lastTime;                 // how long it took you the last time that you played
    public bool doorOpen;

    [Header("You Can Change These")]
    public float torchTimerMax;     // the max amount of time on your torch, also the amount the torch starts with
    float torchSpeedMod;            // the modifier that changes how fast the torch goes out
    public float torchSpeedNormal;  // the modifier for the torch's speed when the player is not sprinting
    public float torchSpeedSprint;  // the modifier for the torch's speed when the player is sprinting
    public float relightAmount;     // how much more time to add to the time on your torch when it is relit
    public int torchesToLightTotal; // how many torches need to be lit to win

    [Header ("Connect To Objects In Unity Scene")]
    public PlayerMotor playerMotor;     // connects this script to the player in the scene
    // public Slider torchRemainingSlider; // slider to show the current status of the torch (time remaining without numbers)
    // public TMP_Text torchTimeRemaining; // timer to show the current status of the torch (time remaining with numbers)
    // public TMP_Text timeInGame;
    public GameObject pauseMenu;
    bool paused;
    public SceneLoader sceneLoader;
    [SerializeField] PlayerController playerInput;

    void Start()
    {
        torchTimer = torchTimerMax;         // sets the torch timer to the max amount of time on a torch
        torchSpeedMod = torchSpeedNormal;   // make sure that the torch's burning speed is at the normal speed to start
        torchesLit = 0;
        paused = false;
        pauseMenu.SetActive(false);
        doorOpen = false;
    }

    void Update()
    {
        worldTimer += Time.deltaTime;   // tick the world timer up
        if(worldTimer >= 60)            // when a minute has passed, increase the counter for minutes and set seconds back to 0
        {
            worldTimer = 0.0f;
        }

        // timeInGame.text = torchTimer.ToString("00.00");

        if (playerMotor.isSprinting)            // if the player is sprinting, change the torch burning speed to the sprinting burn speed
        {
            torchSpeedMod = torchSpeedSprint;
        }
        else
        {
            torchSpeedMod = torchSpeedNormal;   // if the player is not sprinting, change the torch bruning speed back to nromal
        }
        torchTimer -= Time.deltaTime * torchSpeedMod;
        // torchRemainingSlider.value = torchTimer;    // displays the time left for the torch on a slider
        // torchTimeRemaining.text = Mathf.Floor(torchTimer).ToString();    // displays the time left for the torch with numbers

        // TODO if player lights another torch, add time to the torchTimer and to a counter to check how many have been lit

        if(torchTimer <= 0)
        {
            sceneLoader.GameLose();
            // PlayerPrefs.SetString("WorldTime", worldTimer.ToString("00.00"));
            sceneLoader.ChangeScene("JosieMenu");
        }

        if(torchesLit == torchesToLightTotal)
        {
            doorOpen = true;
            // TODO open door
            Debug.Log("Door Opens");

            sceneLoader.GameWon();
            if(lastTime != null)
            {
                lastTime = PlayerPrefs.GetString("WorldTime");
            }
            else
            {
                lastTime = "Not bad for your first game!";
            }
            PlayerPrefs.SetString("WorldTime", worldTimer.ToString("00.00"));
            sceneLoader.ChangeScene("JosieMenu");
        }
    }

    public void LightTorch()
    {
        torchesLit++;
        torchTimer += relightAmount;
        if(torchTimer > torchTimerMax)
        {
            torchTimer = torchTimerMax;
        }
        playerInput.animController.SetBool("Lighting", false);
        // TODO add change to sprite if needed
    }

    public void TogglePause()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else
        {
            paused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
}