using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastInteraction : MonoBehaviour {
    public Text interactText;

	// Use this for initialization
	void Start () {
        interactText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10) && hit.transform.tag == "Interactable")
        {
            interactText.enabled = true;
        }
        else
        {
            interactText.enabled = false;
        }

    }
}
//delete this comment