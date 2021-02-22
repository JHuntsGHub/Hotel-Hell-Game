/*
 * Author: Bethany Cawthorne.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightScript : MonoBehaviour
{
    //Light is initially set to n=on as that is it's default setting
    public bool on = true;
    
    //Switches the light's state
    //If it was off, it is turned on and switched to yellow, and if it was on it turns off
    public void changeColour()
    {
        on = !on;
        GetComponent<Image>().color = on ? Color.yellow : Color.white;
    }
}
