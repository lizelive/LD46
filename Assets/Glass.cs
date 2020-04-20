using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{

    public Transform waterTransform;
    public float ammount;
    public float pourRate = 1;


    public void Add(float v)
    {
        ammount = Mathf.Clamp01(ammount + v);
    }
    // Update is called once per frame
    void Update()
    {

        var scale = Vector3.one;
        scale.z = ammount;

        waterTransform.localScale = scale;

        var angle = Vector3.Angle(Vector3.up, transform.up);

        if (Physics.Raycast(transform.position, Vector3.down, out var hit))
        {
            var plant = hit.collider.GetComponentInParent<Plant>();
            if (plant)
            {
                var transfer = Mathf.Min(ammount, pourRate * Time.deltaTime);
                ammount -= transfer;
                plant.Water(ammount);
            }
        }
    }
}
