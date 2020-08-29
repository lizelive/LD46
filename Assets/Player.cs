using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Player : MonoBehaviour
{
    public Camera pov;
    public SpringJoint hand;

    public float maxGrabDist = 3;

    void Reset()
    {
        pov = GetComponentInChildren<Camera>();
        hand = GetComponentInChildren<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Inman.I.use)
        {
            if (Physics.Raycast(pov.transform.position, pov.transform.forward, out var hitInfo) && hitInfo.distance < maxGrabDist)
            {
                foreach (var clickable in hitInfo.collider.GetComponentsInParent<IClickable>())
                {
                    clickable.Click(this);
                }
            }
        }
    }

    internal bool LookingAt(Vector3 position)
    {
        return Mathf.Abs(Vector3.Angle(pov.transform.forward, position - pov.transform.position)) < 30;
    }
}
