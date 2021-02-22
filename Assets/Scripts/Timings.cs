/*
 * Author Bethany Cawthorne & Jack Hunt
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Timings is a multipurpose class. It has been implemented as a singleton. The main purpose of this class is to keep consistensy between scenes as well as time the player.
/// </summary>
public class Timings : MonoBehaviour
{
    //the three level timers count how long it takes to complete each level.
    static float level1Timer = 0;
    static float level2Timer = 0;
    static float level3Timer = 0;

    //the three text components are used to display the times.
    private Text time1text;
    private Text time2text;
    private Text time3text;

    //m_Scene holds the active scene.
    Scene m_Scene;

    //c_Scene holds the active scene's name.
    string c_Scene;

    // These can be used to keep track of finished rooms so that if they are re entered, the puzzles remain complete.
    public static bool JacksRoomFinished, BethsRoomFinished, RhysRoomFinished, room102KeycardTaken;
    public static string lastScene;

    //savedInventory holds the player's inventory between scene's.
    public static GameObject[] savedInventory;

    /*
     * The following variables and the Awake() method force this class to be a singleton.
     */
    private static Timings instance;

    /// <summary>
    /// Awake does some maintenance. It maintaines Timings as a singleton.
    /// </summary>
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance != null && instance != this)
            Destroy(gameObject);
        else if (SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "GameWon" || SceneManager.GetActiveScene().name == "Times")
        {
            InitialiseTextObjects();
            DisplayTimes();
            Destroy(gameObject);
        }
        else
        {
            instance = this;

            savedInventory = null;
            JacksRoomFinished = false;
            BethsRoomFinished = false;
            RhysRoomFinished = false;
            room102KeycardTaken = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Scene = SceneManager.GetActiveScene();
        c_Scene = m_Scene.name;
        if (c_Scene == "Times")
        {
            DisplayTimes();
        }
        else if(c_Scene == "1-Jacks")
        {
            level1Timer = 0;
            level2Timer = 0;
            level3Timer = 0;

            savedInventory = null;
            JacksRoomFinished = false;
            BethsRoomFinished = false;
            RhysRoomFinished = false;
            room102KeycardTaken = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the active scene, and updates the appropriate timer for teh scene that if loaded
        //For example if the player is in Beth's room, the level2 timer will increase
        m_Scene = SceneManager.GetActiveScene();
        c_Scene = m_Scene.name;

        if (c_Scene == "1-Jacks")
        {
            level1Timer += Time.deltaTime;
        }
        if (c_Scene == "4-Beth")
        {
            level2Timer += Time.deltaTime;
        }
        if (c_Scene == "3-Rhys")
        {
            level3Timer += Time.deltaTime;
        }

        //When the button is pressed, it will update the saved timings for the current scene
        //This is for testing purposes; for the actual playtest it is coded elsewhere to 
        //stop and save the timer when the room is completed
        if (Input.GetKeyDown(KeyCode.L))
        {
            updateTimes(c_Scene);
        }
    }

    //Function to display the saved times that are saved
    //This is used in the timings scene to save the timings from the playtests
    //so we can use this data to improve the game
    //It gets the times that are stored in the player preferences
    void DisplayTimes()
    {
        time1text.text = "Level One:" + PlayerPrefs.GetFloat("level1Timer").ToString();
        time2text.text = "Level Two:" + PlayerPrefs.GetFloat("level2Timer").ToString();
        time3text.text = "Level Three:" + PlayerPrefs.GetFloat("level3Timer").ToString();
    }

    private void InitialiseTextObjects()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("TimeText"))
        {
            if (go.name == "Level1Time")
                time1text = go.GetComponent<Text>();
            else if (go.name == "Level2Time")
                time2text = go.GetComponent<Text>();
            else if (go.name == "Level3Time")
                time3text = go.GetComponent<Text>();
        }
    }

    //Updates the time depending on which scene is open
    //For example if the player finishes Jack's room, it will update the timings for level 1
    public static void updateTimes(string c_Scene){
        if (c_Scene == "1-Jacks")
            {
                PlayerPrefs.SetFloat("level1Timer", level1Timer);
            }
            if (c_Scene == "4-Beth")
            {
                PlayerPrefs.SetFloat("level2Timer", level2Timer);
            }
            if (c_Scene == "3-Rhys")
            {
                PlayerPrefs.SetFloat("level3Timer", level3Timer);
            }
    }
}
