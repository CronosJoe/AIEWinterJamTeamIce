using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Outside connections")]
    [SerializeField] GameObject playerController;
    [SerializeField] Vector3 cameraOffsetDistance;
    [Header("Adjustables")]
    [Range(0.01f,1.0f)]
    [SerializeField] float smoothFaction = .5f; //defaulting to .5
    [SerializeField] bool lookAtTarget = false;
    [SerializeField] bool shouldRotate = true;
    [Range(0,10)]
    [SerializeField] float rotationSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffsetDistance = transform.position - playerController.transform.position;
    }

    // LateUpdate is called once per frame after update
    void LateUpdate()
    {
        if (shouldRotate)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(playerController.GetComponent<PlayerController>().playersInputTracker.currentActionMap["CameraRotate"].ReadValue<float>() * rotationSpeed, Vector3.up);

            cameraOffsetDistance = camTurnAngle * cameraOffsetDistance;
        }

        Vector3 newPos = playerController.transform.position + cameraOffsetDistance;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFaction);

        if (lookAtTarget || shouldRotate)
        {
            transform.LookAt(playerController.transform);
        }
    }
    public void ToggleLock() 
    {
        shouldRotate = !shouldRotate;
    }
}
