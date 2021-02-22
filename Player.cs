/*
 * Author: Jack Hunt
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player is a simple class that takes care of the player's movement.
/// </summary>
public class Player : MonoBehaviour
{
    //[Range(10f, 5000f)]
    private float moveSpeed = 997;

    //[Range(10f, 1600f)]
    private float maxMoveSpeed = 194;
    
    //rigidbody is the player's rigidbody.
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
    }

    /// <summary>
    /// DoMovement() is where the player's movement is done. This is achieved by applying force to the player's rigidbody.
    /// </summary>
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
}
