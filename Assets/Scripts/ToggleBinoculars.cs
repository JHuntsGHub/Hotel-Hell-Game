using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBinoculars : MonoBehaviour
{
    public Camera main;
    public Camera binocular;
    bool camSwitch = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Toggles between two cameras when the space bar is clicked
        //The binocular camera renders everything whereas the main camera does not render
        //the layer the bloody notes are on, meaning that only the binocular camera can see the notes
        if (Input.GetKeyDown(KeyCode.Space))
        {
            camSwitch = !camSwitch;
            main.gameObject.SetActive(camSwitch);
            binocular.gameObject.SetActive(!camSwitch);
        }
    }
}
