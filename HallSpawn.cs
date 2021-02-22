/*
 * Author: Jack Hunt
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// HallSpawn determines where the player should be positioned in the corridoor when they enter the scene.
/// </summary>
public class HallSpawn : MonoBehaviour
{
    //Three transforms to place the player depending on the last scene they were in.
    public Transform JacksDoor, BethsDoor, RhysDoor;

    /// <summary>
    /// The Start method is all that is needed here.
    /// It looks at what scene the player was in last and from that places the player in the current scene.
    /// It also takes care of the scene's continuity by ensuring that the keycard isn't there if the player already picked it up.
    /// </summary>
    private void Start()
    {
        string lastScene = Timings.lastScene;
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (lastScene == "1-Jacks")
            player.transform.SetPositionAndRotation(JacksDoor.position, JacksDoor.rotation);
        else if (lastScene == "3-Rhys")
            player.transform.SetPositionAndRotation(RhysDoor.position, RhysDoor.rotation);
        else if (lastScene == "4-Beth")
            player.transform.SetPositionAndRotation(BethsDoor.position, BethsDoor.rotation);

        if(Timings.room102KeycardTaken == true)
        {
            foreach (GameObject go in FindObjectsOfType<GameObject>())
                if (go.tag == "Item" && go.GetComponent<Item>().ItemName == "Room 102 Keycard")
                    go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y - 20f, go.transform.position.z);
        }
    }
}
