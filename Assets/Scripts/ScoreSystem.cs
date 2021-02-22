
/*
 * Author: Bethany Cawthorne.
 */
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    //Sets up the score as a public static int so that it can be easily referenced and altered in other scripts
    //and so that it is consistent throughout the game
    public static int score = 1000;
    float decreaseTime = 5;
    float timeSinceDecrease = 5;

    void Start()
    {
        //Initializes the score at 1000
        score = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        //Sets up a timer so every three seconds the score is reduced
        //If the timer is at less than zero, it will decrease the score and reset the timer
        //If it is above zero, it will continue subtracting from the timer
        if (timeSinceDecrease <= 0)
        {
            score -= 1;
            timeSinceDecrease = decreaseTime;
        }
        else
        {
            timeSinceDecrease -= Time.deltaTime;
        }
    }
}
