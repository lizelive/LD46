﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int size = 1;
    public Fractal plant;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.KeypadPlus)) size++;
        if(Input.GetKeyDown(KeyCode.KeypadMinus)) size--;
        
        

        var changesNeeded = size - plant.Size;
        if(changesNeeded > 0){
            print($"adding want {size} have {plant.Size}");
            for (int i = 0; i < changesNeeded; i++)
            {
                plant.Add();
            }
        }
        if(changesNeeded < 0)
        {
            print($"removing want {size} have {plant.Size}");
            for (int i = 0; i < -changesNeeded; i++)
            {
                plant.KillChild();
            }
        }

        //print($"eof have {size} but want {plant.Size}");


        

    }
}
