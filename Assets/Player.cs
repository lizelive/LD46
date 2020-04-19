using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera pov;
    public SpringJoint hand;

    public float maxGrabDist = 10;

    void Reset()
    {
        pov = GetComponentInChildren<Camera>();
        hand = GetComponentInChildren<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {


        var holdingStuff = !!hand.connectedBody;
        if (holdingStuff)
        {
            //hand.connectedBody.transform.up = Vector3.up;
        }

        var grabOrSomething = Input.GetButtonDown("Fire1");
        if (grabOrSomething)
        {
            print("do grab");
            if (!holdingStuff)
            {
                if (Physics.Raycast(pov.Ray(), out var hit, maxGrabDist))
                {
                    var grabbable = hit.transform.GetComponentInParent<Rigidbody>();
                    if (grabbable)
                    {
                        hand.connectedAnchor = grabbable.centerOfMass + 0.1f* Vector3.up;
                        hand.connectedBody = grabbable;
                    }
                }
            }
            else
            {
                hand.connectedBody = null;
            }

        }
    }
}
