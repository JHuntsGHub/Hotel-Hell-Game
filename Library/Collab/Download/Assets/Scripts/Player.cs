/*
 * Author: Jack Hunt
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[Range(10f, 5000f)]
    private float moveSpeed = 997;

    //[Range(10f, 1600f)]
    private float maxMoveSpeed = 194;
    
    private new Rigidbody rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DoMovement();
        ManageInventory();
    }

    private void DoMovement()
    {

        float forwardForce, strafeForce;
        forwardForce = Input.GetAxis("Forward") * moveSpeed;
        strafeForce = Input.GetAxis("Strafe") * moveSpeed;
        
        //if(rigidbody.velocity.x < maxMoveSpeed && rigidbody.velocity.z < maxMoveSpeed)
        //    rigidbody.AddForce(strafeForce, 0, forwardForce);
        if (rigidbody.velocity.x < maxMoveSpeed)
            rigidbody.AddForce(transform.forward * forwardForce * Time.deltaTime);
        if (rigidbody.velocity.z < maxMoveSpeed)
            rigidbody.AddForce(transform.right * strafeForce * Time.deltaTime);

    }

    private void ManageInventory()
    {

    }
}
