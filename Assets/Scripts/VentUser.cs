/*
 * Author: Bethany Cawthorne.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// VentUser allows the player to enter the vent.
/// </summary>
public class VentUser : MonoBehaviour
{
    public GameObject inventorySlots;

    private void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            if (inventorySlots.GetComponent<Inventory>().FindItem("Screwdriver"))
                inventorySlots.GetComponent<Inventory>().UseScrewdriver();
        }
    }
}

