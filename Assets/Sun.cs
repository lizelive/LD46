using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    public float speed = 1;
    public float offset;
    const float Day = 60*60*24;
    // Update is called once per frame
    void Update()
    {
        var daytime =  (Time.time * (speed/Day) + offset) % 1;
        transform.eulerAngles = Vector3.left * (daytime*360f);
    }
}
