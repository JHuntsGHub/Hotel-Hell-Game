/*
 * Author: Jack Hunt & Rhys Williams.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Keypad_Code : MonoBehaviour
{
    //combinationInputField is the input field that takes the puzzle's pin.
    public InputField combinationInputField;

    //KeyCard_prefab holds the prefab for the red keycard.
    public GameObject KeyCard_prefab;

    //RoomKey holds the prefab for the room's key.
    public GameObject RoomKey;

    //CardPosition holds the transform for the keycard to spawn at.
    public Transform CardPosition;

    //KeyPosition holds the transform for the key to spawn at.
    public Transform KeyPosition;

    //InventorySlots holds the player's inventory.
    public GameObject InventorySlots;

    // userCombination holds the combination the user enters.
    int[] userCombination;

    // combination holds the correct combination.
    int[] combination;

    // CorrectCode is a boolean that turns true when the correct code is entered.
    bool CorrectCode = false;

    // Start is called before the first frame update
    void Start()
    {
        userCombination = new int[4];
        //Setting the array to 0.
        combination = new int[] { 8, 2, 6, 1 };
    }

    // Update is called once per frame
    void Update()
    {
        
        //Reset();

    }

    //void Combination()
    //{
        

    //    if(CorrectCode = false)
    //    {

    //        if (digit1 == 8)
    //        {

    //        }
            

    //        if (digit2 == 2)
    //        {

    //        }

    //        if (digit3 == 9)
    //        {

    //        }

    //        if (digit4 == 5)
    //        {

    //        }

    //        if (combination == new int[] { 8, 2, 9, 5})
    //        {
    //            CorrectCode = true;
    //        }

    //        else
    //        {
    //            CorrectCode = false;
    //        }

    //    }

        

        
        
    //}

    
    
    //void Reset()
    //{
    //    if (Input.GetKeyDown(KeyCode.C))
    //    {
    //        DoWrongCodeStuff();
    //    }
    //}

    /// <summary>
    /// EnterNumber is called every time the input field changes. It compares the user's code to the correct one.
    /// </summary>
    /// <param name="numberInput">the code entered by the user.</param>
    public void EnterNumber(string numberInput)
    {
        if(combinationInputField.text.Length == 4)
        {
            for(int i = 0; i < numberInput.ToCharArray().Length; i++)
            {
                //Takes the numbers and stores them within the array.
                userCombination[i] = (int)char.GetNumericValue(numberInput.ToCharArray()[i]);
            }
            Debug.Log("UserCode: " + userCombination[0] + userCombination[1] + userCombination[2] + userCombination[3]);
            Debug.Log("ActualCode: " + combination[0] + combination[1] + combination[2] + combination[3]);

            if (userCombination[0] == combination[0] &&
                userCombination[1] == combination[1] &&
                userCombination[2] == combination[2] &&
                userCombination[3] == combination[3])
            {
                CorrectCode = true;
                DoCorrectCodeStuff();
            }
            else
            {
                combinationInputField.text = "";
                DoWrongCodeStuff();
            }
        }
    }

    /// <summary>
    /// DoCorrectCodeStuff is triggered when the correct code is entered. It spawns the keycard.
    /// </summary>
    void DoCorrectCodeStuff()
    {
        Debug.Log("Correct code entered");

        ReleaseLiftKeyCard();

    }

    /// <summary>
    /// DoWrongCodeStuff is triggered when the wrong code is entered. It decreases the timer.
    /// </summary>
    void DoWrongCodeStuff()
    {
        Debug.Log("Wrong code entered");
        combinationInputField.text = "";

        MonsterTimer.decreaseTimer(30);

    }

    /// <summary>
    /// OnTriggerStay allows the player to enter the code while beside the keypad.
    /// </summary>
    /// <param name="coll">The collider that has been hit</param>
    void OnTriggerStay(Collider coll)
    {
        if(coll.gameObject.tag == "KeyPad")
        {
            if (Input.GetKey(KeyCode.E))
            {
                EventSystem.current.SetSelectedGameObject(combinationInputField.gameObject, null);
            }
        }
    }

    /// <summary>
    /// ReleaseLiftKeyCard spawns the keys once the keycode is entered correctly.
    /// </summary>
    void ReleaseLiftKeyCard()
    {
        //Instantiate(KeyCard_prefab, CardPosition.transform.position, CardPosition.transform.rotation);
        //Instantiate(RoomKey, KeyPosition.transform.position, KeyPosition.transform.rotation);
        InventorySlots.GetComponent<Inventory>().AddItem(KeyCard_prefab);
        InventorySlots.GetComponent<Inventory>().AddItem(RoomKey);
    }

}
