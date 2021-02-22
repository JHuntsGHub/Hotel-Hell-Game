/*
 * Author: Bethany Cawthorne.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LightsOut : MonoBehaviour

{
    public GameObject[] ButtonList;
    public GameObject player;
    public GameObject puzzleCamera;
    public GameObject code;
    public GameObject InventorySlots;

    int onCounter = 9;
    bool noteGiven = false;

    //Sets up the player entering the puzzle
    public void initialize()
    {
        //Toggles to a puzzle camera that is centred on the puzzle, which also disables movement
        puzzleCamera.SetActive(true);
        player.SetActive(false);

        //Initializes the lights
        //When the Lights Out puzzle is entered, the lights are all reset to ensure they are all turned on
        //This uses a list containing all of the lights and loops through them until they are all on
        for (int i = 0; i < ButtonList.Length; i++)
        {
            ButtonList[i].GetComponent<Image>().color = Color.yellow;
        }

    }

    //Script to control the changing of the lights
    //When the lights are interacted with, it calls this function with the parameter of the number (name) of the light pressed
    public void pressButton(int name)
    {
        //Calls the turn function to switch the colour from on to off, or off to on
        //Also calls the function for the lights above and below by adding and subtracting three to the number of the light hit
        turn(name);
        turn(name + 3);
        turn(name - 3);
        
        //Checks to see if the hit light is on the right hand edge - if it isn't, it turns the one to the left of it
        if (name%3 != 1)
        {
            turn(name - 1);
        }

        //Checks to see if the hit light is on the left hand edge - if it isn't, it turns the one to the right of it
        if (name % 3 != 0)
        {
            turn(name + 1);
        }

        //Initializes the counter of how many are on so the game can keep track of if they are all turned off
        onCounter = 9;

        //Checks how many lights are on after that turn
        //For each light that is off, it subtracts one from the counter
        for (int i = 0; i < ButtonList.Length; i++)
        {
            if (ButtonList[i].GetComponent<LightScript>().on == false)
            {
                onCounter -= 1;
            }
        }


        //If all of the lights are off, and the player hasn't recieved the note showing the code, the player is given the code
        //This also switches the camera back and re-enables movement
        //It sets the note bool to false so the player cannot collect any more
        if (onCounter == 0 && noteGiven == false)
        {
            InventorySlots.GetComponent<Inventory>().AddItem(code);
            puzzleCamera.SetActive(false);
            player.SetActive(true);
            noteGiven = true;

        }
    }

    //This function is triggered when a light is clicked, or a light next to it is clicked
    //It checks that the number is one of the possible numbers
    //Then it changes the colour
    void turn(int name)
    {
        if (name < 1 || name > 9) return;

        //Gets the gameobject from the button list and calls a function from it
        GameObject turnButton = ButtonList[name-1];
        turnButton.GetComponent<LightScript>().changeColour();
    }
}
