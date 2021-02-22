/*
 * Author: Bethany Cawthorne.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        //Sets the score text to display the score
        scoreText.text = "Score: " + ScoreSystem.score;
    }

        
}
