using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
public class PlayerController : MonoBehaviour
{
    [Header("Player Input")]
    public PlayerInput playersInputTracker;
    [Header("Outside references")]
    [SerializeField] PlayerMotor motor;
    public Animator animController;
    [SerializeField] Timer timerScript; //don't change jut reference
    [SerializeField] CameraMovement cameraController;
    [Header("editable")]
    [SerializeField] int torchLightDistance;
    [Range(0,1)]
    [SerializeField] float delay;
    private Vector2 moveVec;
    private GameObject closestTorch = null; //this will be used to store
    private void OnEnable() //this will enable all of our input events when the object is enabled in the scene
    {
        playersInputTracker.currentActionMap["Sprint"].performed += ToSprint;
        playersInputTracker.currentActionMap["Fire"].performed += LightTorch;
        playersInputTracker.currentActionMap["Pause"].performed += PauseButton;
        playersInputTracker.currentActionMap["CameraLock"].performed += ToggleCamera;
    }


    private void OnDisable() //this will let me disable our input events when the object leaves
    {
        try
        {
            playersInputTracker.currentActionMap["Sprint"].performed -= ToSprint; 
            playersInputTracker.currentActionMap["Fire"].performed -= LightTorch;
            playersInputTracker.currentActionMap["Pause"].performed -= PauseButton;
        }
        catch (NullReferenceException)
        {
            Debug.LogWarning("Failed to unsubscribe from the input event methods due to the input manager being removed first, this will always occur in non builds", this);
        }
    } 
    private void ToggleCamera(InputAction.CallbackContext obj)
    {
        cameraController.ToggleLock();
    }
    private void PauseButton(InputAction.CallbackContext obj)
    {
        timerScript.TogglePause(); //toggle the pause menu
    }
    private void LightTorch(InputAction.CallbackContext obj) //this will run a check to detect a nearby torch then light it
    {
        if (closestTorch != null)
        {
            if ((closestTorch.transform.position - transform.position).magnitude <= torchLightDistance && !closestTorch.GetComponent<MazeTorch>().lit)
            {
                animController.SetBool("Lighting", true);
                closestTorch.GetComponent<MazeTorch>().LightTorch();

                // start the coroutine
                StartCoroutine(RelightTorch(delay));
            }
        }
    }
    private void ToSprint(InputAction.CallbackContext obj)
    {
        animController.SetBool("Running", !animController.GetBool("Running"));
        motor.DashInput();
    }

    // coroutine delayed for X seconds
    private IEnumerator RelightTorch(float delay)
    {
        // after x seconds 
        yield return new WaitForSeconds(delay);

        // we do the thing
        timerScript.LightTorch();
    }
    

    private void OnTriggerEnter(Collider other) //this is going to be used for the grabbing the torch when they enter the range
    {
        if (other.tag == "torch") 
        {
            if (!other.GetComponent<MazeTorch>().lit)
            {
                Debug.Log("Got new torch");
                closestTorch = other.gameObject;
            }
            //might want to display to play that they can in fact now do the thing
        }
        if(other.tag == "door") 
        {
            //check torches here
            //win
        }
    }
    // Update is called once per frame
    void Update()
    {
        moveVec = playersInputTracker.currentActionMap["Move"].ReadValue<Vector2>(); //taking the value off of the movement
        if (moveVec.magnitude >= 0.1f) 
        {
            animController.SetBool("Walking", true);
        }
        else 
        {
            animController.SetBool("Walking", false);
        }
        motor.MoveInput(new Vector3(moveVec.x, 0.0f, moveVec.y)); //sending to the motor for use
        //will probably want a movement animation call here when we get to that point
    }
}
