using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    [Range(0, 100)]
    [SerializeField] int movementSpeed;
    public bool isSprinting;

    [Header("Player Input")]
    public PlayerInput playersInputTracker;

    private bool move;
    private void OnEnable() //this will enable all of our input events when the object is enabled in the scene
    {
        playersInputTracker.currentActionMap["Move"].performed += MovementInput;
        playersInputTracker.currentActionMap["Sprint"].performed += ToSprint;
    }
    private void OnDisable() //this will let me disable our input events when the object leaves
    {
        playersInputTracker.currentActionMap["Move"].performed -= MovementInput;
        playersInputTracker.currentActionMap["Sprint"].performed -= ToSprint;
    } 
    private void MovementInput(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }
    private void ToSprint(InputAction.CallbackContext obj) 
    {
        throw new System.NotImplementedException();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
