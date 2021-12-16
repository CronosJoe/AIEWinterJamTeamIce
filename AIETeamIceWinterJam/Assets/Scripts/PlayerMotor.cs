using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    // Input handling, these need to be public for Josie to use
    public Vector3 movementVec3; //stealing terry's bool idea cause I liked it
    public bool isSprinting;
    [Header("Outside References")]
    public CharacterController controller; //This does not handle gravity so if we implement slopes in the maze for whatever reason add a gravity function
    public PlayerController playerRef;
    [Header("Player Stats")]
    [Range(0, 50)]
    [SerializeField] float movementSpeed;
    [Range(0, 150)]
    [SerializeField] float sprintSpeed;
    public void MoveInput(Vector3 move)
    {
        movementVec3 = move;
    }
    public void DashInput() 
    {
        isSprinting = !isSprinting;
    }
    private void Update()
    {
        if (movementVec3.magnitude >= .1f) //this will simply stop the below calls from happening if there has been no new input
        {
            float targetAngle = Mathf.Atan2(movementVec3.x, movementVec3.z) * Mathf.Rad2Deg; //changing the direction based on the current movement vector
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f); //setting the new direction
            if (!isSprinting)
            {
                controller.Move(movementVec3 * movementSpeed * Time.deltaTime); //actually moving the player, with a cylinder collider cause charactercontroller moment
            }
            else 
            {
                controller.Move(movementVec3 * sprintSpeed * Time.deltaTime);
            }
        }
    }
}
