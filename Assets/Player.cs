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

    }
}
