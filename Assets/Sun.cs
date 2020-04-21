using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[ExecuteInEditMode]
public class Sun : MonoBehaviour
{
    public Transform[] locations;
    public float timeUntilMove = 30;
    /*
    public float speed = 1;
    public float offset;
    const float Day = 60*60*24;

    var daytime = (Time.time * (speed / Day) + offset) % 1;
    transform.eulerAngles = Vector3.left* (daytime*360f);

    */

    // Update is called once per frame
    void Update()
    {
        timeUntilMove -= Time.deltaTime;
        if (timeUntilMove > 0)
            return;

        var newSpot = locations.Choice();
        transform.rotation = newSpot.rotation;

        timeUntilMove = Random.Range(90, 120);
    }
}
