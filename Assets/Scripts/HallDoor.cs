/*
 * Author: Jack Hunt
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// HallDoor is a simple class to allow the player to move through doors to another scene.
/// </summary>
public class HallDoor : MonoBehaviour
{
    //sceneName is the name of the scene you want to transition too. 
    public string sceneName;

    //InventorySlots is a the player's inventory. This is used to save the inventory between levels.
    public GameObject InventorySlots;

    //OnTriggerStay is called when a player is in front of a door and checks if they should move to a different scene.
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("Loading scene: " + sceneName);
            Timings.lastScene = SceneManager.GetActiveScene().name;
            InventorySlots.GetComponent<Inventory>().SaveInventory();
            SceneManager.LoadScene(sceneName);
        }
    }
}
