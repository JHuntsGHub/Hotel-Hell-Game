/*
 * Author: Bethany Cawthorne.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UnlockMouse unlocks the mouse.
/// </summary>
public class UnlockMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
