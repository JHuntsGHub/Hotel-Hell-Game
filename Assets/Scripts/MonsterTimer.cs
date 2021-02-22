/*
 * Author: Bethany Cawthorne.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonsterTimer : MonoBehaviour
   
{
    public AudioSource MonsterAudio;
    public GameObject JumpCam;
    public Image Vignette;
    private static float gameTimer;
    private float maxTimer;

    private void Start()
    {
        //Sets the bloody vignette to zero opacity and sets the game timer to the maximum time
        Vignette.color = new Color(Vignette.color.r, Vignette.color.g, Vignette.color.b, 0);
        gameTimer = 300f;
        maxTimer = 300f;
    }
    void Update()
    {
        //As the game updates, the timer counts down. 
        if(gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
            //If the game timer reaches zero, the coroutine for the jumpscare plays
        } else if(gameTimer > -100)
        {
            StartCoroutine(JumpScare());
            gameTimer = -100;
        }

        Vignette.color = new Color(Vignette.color.r, Vignette.color.g, Vignette.color.b, 1-(gameTimer*(1/maxTimer)));
    }

    //Function that allows other scripts to decrement the timer
    //The time to reduce the timer by is passed in as a parameter
    //This is used in the raycast interaction script so if the player tries to use the wrong object in the wrong place, they are given a penalty
    public static void decreaseTimer(int decrement)
    {
        gameTimer -= decrement;
    }

    //The coroutine plays a monster screaming sound and enables a camera with an animated monster attatched to it
    //so that the monster overlays the screen and jumpscares the player
    //After two seconds, the game switches to a game over screen
    IEnumerator JumpScare()
    {
        MonsterAudio.Play();
        JumpCam.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");
    }
}
