﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{

    public Transform waterTransform;
    public float ammount;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var angle = Vector3.Angle(Vector3.up, transform.up);


        if(Physics.Raycast(transform.position, Vector3.down, out var hit)){
            
        }
    }
}