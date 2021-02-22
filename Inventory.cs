/*
 * Author: Jack Hunt
 * (Two labelled functions by Bethany Cawthorne)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// Inventory takes care of the player's inventory. 
/// </summary>
public class Inventory : MonoBehaviour
{
    //inventorySlotImages holds the sprites to display in the UI
    public Image[] inventorySlotImages = new Image[8];

    //defaultSprite holds the default sprite to display in the UI
    public Sprite defaultSprite;

    //fixedKey holds the fixedKey prefab for when the player fixes the key.
    public GameObject fixedKey;

    //bathroomDoor holds the bathroomDoor gameObject.
    public GameObject bathroomDoor;

    //screwdriver holds the scredriver prefab.
    public GameObject screwdriver;

    //SafeObject holds the Safe gameObject.
    public GameObject SafeObject;

    //currentItemText holds the Text object that displays the currently selected object.
    public Text currentItemText;

    //defaultItemText is the default text to display when the player has no item selected.
    private string defaultItemText = "No Item Selected.";

    //inventorySlotItems holds the actual gameObjects that comprimise the player's inventory.
    private GameObject[] inventorySlotItems = new GameObject[8];

    //indexOfLastInsertion is the index where the last object was inserted into the inventory. defaults at -1.
    private int indexOfLastInsertion = -1;

    //currentlySelectedItemIndex is the index of the currently selected item.
    private int currentlySelectedItemIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        ReintroduceInventory();
    }

    //Gets called every frame.
    void Update()
    {
        TakeInput();
        UseGlue();

        if (inventorySlotItems[currentlySelectedItemIndex] == null)
            currentItemText.text = defaultItemText;
        else
            currentItemText.text = inventorySlotItems[currentlySelectedItemIndex].GetComponent<Item>().ItemName;
    }

    /// <summary>
    /// ReintroduceInventory gives the player their inventory back from saved space when they traverse between the scenes.
    /// </summary>
    public void ReintroduceInventory()
    {
        if(Timings.savedInventory == null)
        {
            for (int i = 0; i < inventorySlotItems.Length; i++)
                inventorySlotItems[i] = null;

            foreach (Image i in inventorySlotImages)
                i.sprite = defaultSprite;
        }
        else
        {
            inventorySlotItems = Timings.savedInventory;
            Debug.Log("inventory restored from save.");

            //Debug.Log("Inventory:");
            //foreach (GameObject go in inventorySlotItems)
            //{
            //    if (go == null)
            //        Debug.Log("null");
            //    else
            //        Debug.Log(go.GetComponent<Item>().ItemName);
            //}

            for(int i = 0; i < inventorySlotItems.Length; i++)
            {
                if (inventorySlotItems[i] == null)
                    inventorySlotImages[i].sprite = defaultSprite;
                else
                    inventorySlotImages[i].sprite = inventorySlotItems[i].GetComponent<Item>().ItemImage;
            }
        }

        Timings.savedInventory = null;
    }

    /// <summary>
    /// SaveInventory saves the player's inventory when they change scene.
    /// </summary>
    public void SaveInventory()
    {
        Timings.savedInventory = inventorySlotItems;

        //Debug.Log("Saved Inventory:");
        //foreach (GameObject go in Timings.savedInventory)
        //{
        //    if (go == null)
        //        Debug.Log("null");
        //    else
        //        Debug.Log(go.GetComponent<Item>().ItemName);
        //}
    }

    /// <summary>
    /// TakeInput takes the player's keyboard input and uses it to select an item in the inventory.
    /// </summary>
    private void TakeInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            SelectItem(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            SelectItem(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            SelectItem(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            SelectItem(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
            SelectItem(4);
        else if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
            SelectItem(5);
        else if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
            SelectItem(6);
        else if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
            SelectItem(7);
    }

    /// <summary>
    /// AddItem will add an item to the inventory array.
    /// Returns true if successfull, false if not (inventory full).
    /// </summary>
    /// <param name="itemToAdd">The GameObject you want to add.</param>
    /// <returns>Returns true if successfull,
    /// false if not (inventory full or the object did not have the Item script attatched).</returns>
    public bool AddItem(GameObject itemToAdd)
    {
        if (itemToAdd.GetComponentInChildren<Item>() == null)
        {
            Debug.Log("ERROR: Item script not found...");
            return false;
        }
        for (int i = 0; i < inventorySlotItems.Length; i++)
        {
            if (inventorySlotItems[i] == null)
            {
                inventorySlotItems[i] = itemToAdd;
                indexOfLastInsertion = i;
                inventorySlotImages[i].sprite = itemToAdd.GetComponent<Item>().ItemImage;
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// This removes the last object added.
    /// </summary>
    /// <returns>Returns true if successfully removed item.
    /// Returns false if no item has been added yet or called a second time.</returns>
    public bool RemoveLastItemAdded()
    {
        if (indexOfLastInsertion == -1)
            return false;
        else
        {
            inventorySlotItems[indexOfLastInsertion] = null;
            indexOfLastInsertion = -1;
            inventorySlotImages[indexOfLastInsertion].sprite = defaultSprite;
            return true;
        }
    }

    /// <summary>
    /// Removes item from inventory.
    /// </summary>
    /// <param name="itemName">A string of the GameObjects nems. Removes the first found.</param>
    /// <returns>Returns true if item removed, false otherwise.</returns>
    public bool RemoveItem(string itemName)
    {
        for (int i = 0; i < inventorySlotItems.Length; i++)
        {
            if (inventorySlotItems[i] != null && inventorySlotItems[i].GetComponent<Item>().ItemName == itemName)
            {
                inventorySlotItems[i] = null;
                inventorySlotImages[i].sprite = defaultSprite;
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Removes item from inventory.
    /// </summary>
    /// <param name="itemToRemove">A GameObject to be removed. Removes the first found.</param>
    /// <returns>Returns true if item removed, false otherwise.</returns>
    public bool RemoveItem(GameObject itemToRemove)
    {
        for (int i = 0; i < inventorySlotItems.Length; i++)
        {
            if (inventorySlotItems[i] == itemToRemove)
            {
                inventorySlotItems[i] = null;
                inventorySlotImages[i].sprite = defaultSprite;
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// !!BE CAREFULL!!
    /// Removes item from inventory.
    /// </summary>
    /// <param name="itemToRemove">.Removes the item at index in player's inventory array. (Player's inventoy array is size 8.)</param>
    /// <returns>Returns true if item removed, false otherwise.</returns>
    public bool RemoveItem(int indexOfItemToBeRemoved)
    {
        if (indexOfItemToBeRemoved < 0 || indexOfItemToBeRemoved >= inventorySlotItems.Length)
            return false;
        else
        {
            inventorySlotItems[indexOfItemToBeRemoved] = null;
            inventorySlotImages[indexOfItemToBeRemoved].sprite = defaultSprite;
            return true;
        }
    }

    /// <summary>
    /// Searches for an item in the inventory by name.
    /// </summary>
    /// <param name="itemName">The name attatched to the item's Item script.</param>
    /// <returns>Returns true if found, false if not.</returns>
    public bool FindItem(string itemName)
    {
        for (int i = 0; i < inventorySlotItems.Length; i++)
        {
            if (inventorySlotItems[i] != null && inventorySlotItems[i].GetComponent<Item>().ItemName == itemName)
                return true;
        }

        return false;
    }

    /// <summary>
    /// SelectItem makes an item the currently selected item.
    /// </summary>
    /// <param name="index">the index in the player's inventory</param>
    /// <returns>true if successful</returns>
    public bool SelectItem(int index)
    {
        if (index >= inventorySlotItems.Length || index < 0)
            return false;

        currentlySelectedItemIndex = index;
        return true;
    }

    /// <summary>
    /// UseGlue() uses the glue item to fix the red key.
    /// </summary>
    /// <returns></returns>
    public bool UseGlue()
    {
        if (inventorySlotItems[currentlySelectedItemIndex] != null)
        {
            if (Input.GetKeyDown(KeyCode.E) && inventorySlotItems[currentlySelectedItemIndex].GetComponent<Item>().ItemName == "Supa Glue")
            {
                if (FindItem("Red Key Bit") && FindItem("Red Key Handle"))
                {
                    RemoveItem("Red Key Bit");
                    RemoveItem("Red Key Handle");
                    RemoveItem("Supa Glue");
                    AddItem(fixedKey);
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// UseGoldenKey uses the golden key item to open the bathroom door.
    /// </summary>
    /// <returns>true if sucessful</returns>
    public bool UseGoldenKey()
    {
        if(inventorySlotItems[currentlySelectedItemIndex] != null)
        {
            if (inventorySlotItems[currentlySelectedItemIndex].GetComponent<Item>().ItemName == "Golden Key")
            {
                if (FindItem("Golden Key"))
                {
                    RemoveItem("Golden Key");
                    bathroomDoor.GetComponent<DoorOpen>().OpenDoor();
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// UseRedKey() uses the red key to open the first room's door.
    /// </summary>
    /// <returns>true if sucessful</returns>
    public bool UseRedKey()
    {
        if (inventorySlotItems[currentlySelectedItemIndex] != null)
        {
            if (inventorySlotItems[currentlySelectedItemIndex].GetComponent<Item>().ItemName == "Fixed Red Key")
            {
                if (FindItem("Fixed Red Key"))
                {
                    RemoveItem("Fixed Red Key");
                    Timings.updateTimes("1-Jacks");
                    Timings.JacksRoomFinished = true;
                    Timings.lastScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                    SaveInventory();
                    UnityEngine.SceneManagement.SceneManager.LoadScene("0-Coridoor");
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// UseRoom102Key() uses the key to enter room 102
    /// </summary>
    /// <returns>true if sucessful</returns>
    public bool UseRoom102Key()
    {
        if (inventorySlotItems[currentlySelectedItemIndex] != null)
        {
            if (inventorySlotItems[currentlySelectedItemIndex].GetComponent<Item>().ItemName == "Room 102 Keycard")
            {
                Timings.room102KeycardTaken = true;
                Timings.lastScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                SaveInventory();
                UnityEngine.SceneManagement.SceneManager.LoadScene("4-Beth");
                return true;
            }
        }

        return false;
    }

    //Author of this function: Bethany Cawthorne
    //If an object is selected in the inventory, and the currently selected item is named 'screwdriver'
    //the screwdriver will be used to unscrew the vent and move onto the next level
    //The function also removes the screwdriverm and updates the level timings as the level is complete
    public bool UseScrewdriver()
    {
        if (inventorySlotItems[currentlySelectedItemIndex] != null)
        {
            if (inventorySlotItems[currentlySelectedItemIndex].GetComponent<Item>().ItemName == "Screwdriver")
            {
                if (FindItem("Screwdriver"))
                {
                    RemoveItem("Screwdriver");
                    Timings.updateTimes("4-Beth");
                    Timings.BethsRoomFinished = true;
                    Timings.lastScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                    SaveInventory();
                    UnityEngine.SceneManagement.SceneManager.LoadScene("3-Rhys");
                    return true;
                }
            }
        }

        return false;
    }


    //Author of this function: Bethany Cawthorne
    //If an object is selected in the inventory, and the currently selected item is named 'code'
    //it will open the safe and save the inventory
    public bool UseCodeNote()
    {
        if (inventorySlotItems[currentlySelectedItemIndex] != null)
        {
            if (inventorySlotItems[currentlySelectedItemIndex].GetComponent<Item>().ItemName == "Code")
            {
                if (FindItem("Code"))
                {
                    SafeObject.GetComponent<Safe>().openSafe();
                    SaveInventory();
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// UseLiftKey() uses the lift key to end the game.
    /// </summary>
    /// <returns>true if sucessful</returns>
    public bool UseLiftKey()
    {
        if (inventorySlotItems[currentlySelectedItemIndex] != null)
        {
            if (inventorySlotItems[currentlySelectedItemIndex].GetComponent<Item>().ItemName == "Lift Keycard")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameWon");
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// UseRoom103Key() uses the key to exit room 103
    /// </summary>
    /// <returns>true if sucessful</returns>
    public bool UseRoom103Key()
    {
        if (inventorySlotItems[currentlySelectedItemIndex] != null)
        {
            if (inventorySlotItems[currentlySelectedItemIndex].GetComponent<Item>().ItemName == "Room 103 Key")
            {
                RemoveItem("Room 103 Key");
                Timings.updateTimes("3-Rhys");
                Timings.RhysRoomFinished = true;
                Timings.lastScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                SaveInventory();
                UnityEngine.SceneManagement.SceneManager.LoadScene("0-Coridoor");
                return true;
            }
        }

        return false;
    }
}