/*
 * Author: Jack Hunt.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// KeyUser allows the use of the various keys within the game.
/// </summary>
public class KeyUser : MonoBehaviour
{
    //inventorySlots is the player's inventory.
    public GameObject inventorySlots;

    /// <summary>
    /// OnTriggerStay get's called when in front of a door allowing use of a key.
    /// </summary>
    /// <param name="coll">The detected collision</param>
    private void OnTriggerStay(Collider coll)
    {
        if(coll.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            if (inventorySlots.GetComponent<Inventory>().FindItem("Golden Key"))
                inventorySlots.GetComponent<Inventory>().UseGoldenKey();

            else if (inventorySlots.GetComponent<Inventory>().FindItem("Fixed Red Key"))
                inventorySlots.GetComponent<Inventory>().UseRedKey();

            else if (inventorySlots.GetComponent<Inventory>().FindItem("Room 102 Keycard") && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "0-Coridoor" && gameObject.tag != "Lift")
                inventorySlots.GetComponent<Inventory>().UseRoom102Key();

            else if (inventorySlots.GetComponent<Inventory>().FindItem("Lift Keycard") && gameObject.tag == "Lift")
                inventorySlots.GetComponent<Inventory>().UseLiftKey();
                

            else if (inventorySlots.GetComponent<Inventory>().FindItem("Room 103 Key") && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "3-Rhys")
                inventorySlots.GetComponent<Inventory>().UseRoom103Key();

            else if (Timings.JacksRoomFinished && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "1-Jacks")
            {
                Timings.lastScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                UnityEngine.SceneManagement.SceneManager.LoadScene("0-Coridoor");
            }

            //Debug.Log("timings.lastscene: " + Timings.lastScene);
            //Debug.Log("timings.jacksroomfin: " + Timings.JacksRoomFinished);
        }
    }
}
