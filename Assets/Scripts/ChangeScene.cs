/*
 * Author: Bethany Cawthorne.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //Quick access to each player's room on a key press for testing purposes
   void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene("1-Jacks");
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("4-Beth");
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            //When the player transitions, it updates the timings for the finished room
            Timings.updateTimes("4-Beth");
            SceneManager.LoadScene("3-Rhys");
        }
        //Quick way to get to the timings scene to get the times that the playtesters achieved in each room
        else if (Input.GetKeyDown(KeyCode.U))
        {
            SceneManager.LoadScene("Times");
        }
    }


    //Function used for the button clicks
    //It is called when the start or end button is pressed on the UI, and the button click event 
    //passes in the name of the scene the player wants to change to
   public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Allows the player to quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
