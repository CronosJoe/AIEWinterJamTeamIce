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
    [SerializeField] Animator animController;
    private Vector2 moveVec;
    private void OnEnable() //this will enable all of our input events when the object is enabled in the scene
    {
        playersInputTracker.currentActionMap["Sprint"].performed += ToSprint;
        playersInputTracker.currentActionMap["Fire"].performed += LightTorch;
        playersInputTracker.currentActionMap["Pause"].performed += PauseButton;
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
    private void PauseButton(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    private void LightTorch(InputAction.CallbackContext obj) //this will run a check to detect a nearby torch then light it
    {
        animController.SetBool("Lighting", true);
        //implent detect here
        //call that torches lit method
        throw new NotImplementedException();
    }
    private void ToSprint(InputAction.CallbackContext obj) 
    {
        animController.SetBool("Running", !animController.GetBool("Running"));
        motor.DashInput();
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
