/*
 * Author: Jack Hunt.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// CameraMovement takes care of the player's camera.
/// </summary>
public class CameraMovement : MonoBehaviour
{
    //
    private const float ySensetivity = 0.5f;

    //private const int maxXRotate = 65;
    //private const int minXRotate = -45;

    //cameraLocked allows the camera to be locked when appropriate.
    public bool cameraLocked = false;
    
    //Start runs once object is created.
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        if (SceneManager.GetActiveScene().name == "4-Beth")
            Cursor.visible = true;
        else
            Cursor.visible = false;

    }

    //Late Update is when the camera actually updates. This achieves less tearing when compared to in a regular Update method.
    private void LateUpdate()
    {
        if (!cameraLocked)
            RotateCamera();
    }

    /// <summary>
    /// RotateCamera() rotates the camera vertically and actually rotates the player horizontally.
    /// </summary>
    private void RotateCamera()
    {
        // Calculates rotations based on mouse movements.
        float x, y;
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        Vector3 amountToRotateCamera = new Vector3(y * ySensetivity, 0, 0);
        Vector3 amountToRotatePlayer = new Vector3(0, x * -1, 0);

        transform.eulerAngles -= amountToRotateCamera;
        transform.parent.transform.eulerAngles -= amountToRotatePlayer;
    }
}
