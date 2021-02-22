/*
 * Author: Jack Hunt.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The Item class is used to populate the user's inventory with many items
/// </summary>
public class Item : MonoBehaviour
{
    /// <summary>
    /// Awake() does some maintanence. It deletes the object when passing into certain scenes.
    /// </summary>
    void Awake()
    {
        if (SceneManager.GetActiveScene().name != "GameOver" || SceneManager.GetActiveScene().name != "GameWon" || SceneManager.GetActiveScene().name != "Times")
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }

    //ItemImage is the sprite associated with the Item.
    public Sprite ItemImage;

    //ItemName is the name of the Item.
    public string ItemName;
    
}
