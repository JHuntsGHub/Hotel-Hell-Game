/*
 * Author: Jack Hunt.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// JackBedroomSpawn maintains Jack's scene.
/// It resets the room so that it appears as it should when the player reenter. it also positions the player appropriately.
/// </summary>
public class JackBedroomSpawn : MonoBehaviour
{
    //hallDoor is the transform the player should have when reentering the room.
    public Transform hallDoor;

    //bathroomDoor is thr bathroom door game object and bathroomDoorInstantPosition holds the position it should be in.
    public GameObject bathroomDoor, bathroomDoorInstantPosition;

    void Start()
    {
        if(Timings.lastScene == "0-Coridoor")
        {
            foreach (GameObject go in FindObjectsOfType<GameObject>())
                if (go.tag == "Item")
                    Destroy(go);

            bathroomDoor.transform.SetPositionAndRotation(bathroomDoorInstantPosition.transform.position, bathroomDoorInstantPosition.transform.rotation);
            GameObject.FindGameObjectWithTag("Player").transform.SetPositionAndRotation(hallDoor.position, hallDoor.rotation);
        }
    }
}
