using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Safe : MonoBehaviour
{
    public Animator anim;
    public GameObject screwdriver;
    public GameObject InventorySlots;
    
    //Function to open the safe
    //It runs the safe animation, takes away the code note and gives the player the screwdriver
    //This allows the player to progress to the next level
    public void openSafe()
    {
        anim.SetBool("Safe", true);
        InventorySlots.GetComponent<Inventory>().RemoveItem("Code");
        InventorySlots.GetComponent<Inventory>().AddItem(screwdriver);

    }
}
