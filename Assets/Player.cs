using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        if(Input.GetButtonDown("Fire1")){
            if(Physics.Raycast(pov.transform.position , pov.transform.forward , out var hitInfo) && hitInfo.distance < maxGrabDist){
                foreach (var clickable in hitInfo.collider.GetComponentsInParent<IClickable>())
                {
                    clickable.Click(this);
                }
            }
        }
    }


}
