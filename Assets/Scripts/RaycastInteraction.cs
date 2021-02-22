using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastInteraction : MonoBehaviour {
    
    GameObject hitObject;
    public Image code;

    public GameObject InventorySlots;

	// Update is called once per frame
	void Update () {
        //Sends out a raycast
        RaycastHit hit;
        
        //If the user presses E to interact, and the raycast hits something that is a distance of 10 away or lower
        //and the tag is correct, it will do the following programs
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10) && hit.transform.tag == "LightsOut")
            {
                //If the player interacts with the lights out game, it will initialize it 
                hitObject = hit.transform.gameObject;
                hitObject.GetComponent<LightsOut>().initialize();
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10) && hit.transform.tag == "Safe")
            {
                //If the player hits the safe, and is holding the key code to the safe
                //it will call the 'use code note' function which takes away the note and opens teh safe
                if (InventorySlots.GetComponent<Inventory>().FindItem("Code"))
                {
                    InventorySlots.GetComponent<Inventory>().UseCodeNote();
                    hitObject = hit.transform.gameObject;
                }
            }
            else
            {
                //If the player does something incorrectly without the right items, they lose time and score points
                MonsterTimer.decreaseTimer(30);
                ScoreSystem.score -= 10;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            //Adds items to the inventory when they are hit with a raycast
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10) && hit.transform.tag == "Item")
            {
                //Debug.Log("Adding item to inventory.");
                InventorySlots.GetComponent<Inventory>().AddItem(hit.transform.gameObject);
                hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y - 20f, hit.transform.position.z);
            }
        }
    }
}