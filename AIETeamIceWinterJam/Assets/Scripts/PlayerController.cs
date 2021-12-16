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
    private Vector2 moveVec;
    private void OnEnable() //this will enable all of our input events when the object is enabled in the scene
    {
        playersInputTracker.currentActionMap["Sprint"].performed += ToSprint;
    }
    private void OnDisable() //this will let me disable our input events when the object leaves
    {
        try
        {
            playersInputTracker.currentActionMap["Sprint"].performed -= ToSprint;
        }
        catch (NullReferenceException)
        {
            Debug.LogWarning("Failed to unsubscribe from the input event methods due to the input manager being removed first, this will always occur in non builds", this);
        }
    } 
    private void ToSprint(InputAction.CallbackContext obj) 
    {
        motor.DashInput();
    }
    // Update is called once per frame
    void Update()
    {
        moveVec = playersInputTracker.currentActionMap["Move"].ReadValue<Vector2>(); //taking the value off of the movement
        motor.MoveInput(new Vector3(moveVec.x, 0.0f, moveVec.y)); //sending to the motor for use
        //will probably want a movement animation call here when we get to that point
    }
}
