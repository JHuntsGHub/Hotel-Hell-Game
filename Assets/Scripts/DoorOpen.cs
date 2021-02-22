/*
 * Author: Jack Hunt.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    //Two bools here: doorIsOpening is true while the door is opening, doorIsOpen is true while the door is open.
    private bool doorIsOpening, doorIsOpen;

    //rotateSpeed controls the speed at which the door rotates.
    [Range(1f, 50f)]
    public float rotateSpeed = 30f;

    //maxRotation is the maximum amount the door is allowed rotate.
    [Range(0f, 100f)]
    public float maxRotation = 2f;

    public GameObject DoorPivot;

    // Start is called before the first frame update
    void Start()
    {
        doorIsOpening = false;
        doorIsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorIsOpening && !doorIsOpen)
            RotateDoor();
    }

    /// <summary>
    /// RotateDoor is called while the doorIsOpening and !doorIsOpen. This method rotates the door.
    /// </summary>
    private void RotateDoor()
    {
        transform.RotateAround(DoorPivot.transform.position, new Vector3(0, 1, 0), rotateSpeed * Time.deltaTime);

        //Debug.Log("Door rotation's y: " + transform.rotation.ToEulerAngles().y);

        if (transform.rotation.ToEulerAngles().y >= maxRotation)
        {
            doorIsOpen = true;
            doorIsOpening = false;
        }
    }

    /// <summary>
    /// OpenDoor is the method that starts off the door's rotation.
    /// </summary>
    public void OpenDoor()
    {
        doorIsOpening = true;
    }
}
