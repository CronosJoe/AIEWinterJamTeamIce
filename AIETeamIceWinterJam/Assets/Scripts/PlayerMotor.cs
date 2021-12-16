using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    // Input handling, these need to be public for Josie to use
    public Vector3 isMoving; //stealing terry's bool idea cause I liked it
    public bool isSprinting;
    [Header("Outside References")]
    public CharacterController controller; //This does not handle gravity so if we implement slopes in the maze for whatever reason add a gravity function
    [Header("Player Stats")]
    [Range(0, 50)]
    [SerializeField] float movementSpeed;
    [Range(0, 150)]
    [SerializeField] float sprintSpeed;
    [Header("Body")]
    public Transform dummyReference; //might not need cause I'm trying to shortcut movement with character controller
    public PlayerController playerRef;
    public void MoveInput(Vector3 move)
    {
        isMoving = move;
    }
    public void DashInput() 
    {
        isSprinting = !isSprinting;
    }
    private void Update()
    {
        if (isMoving.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(isMoving.x, isMoving.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            if (!isSprinting)
            {
                controller.Move(isMoving * movementSpeed * Time.deltaTime); //actually moving the player, with a cylinder collider cause charactercontroller moment
            }
            else 
            {
                controller.Move(isMoving * sprintSpeed * Time.deltaTime);
            }
        }
    }
}
