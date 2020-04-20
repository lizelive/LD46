using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCheck : MonoBehaviour
{

    public Needy need;

    

    // Update is called once per frame
    void Update()
    {
        need.balance = need.maxValue - GameObject.FindObjectsOfType<Garbage>().Length;
    }
}
