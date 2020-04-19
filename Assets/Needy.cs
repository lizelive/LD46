using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needy : MonoBehaviour
{

    public static bool Freeze;
    public Need need;
    public float balance = 50;
    public float maxValue = 100;
    public float baseRateOfDecay = 1;
    public float RateOfDecay => baseRateOfDecay;

    void Update(){
        if(Freeze)
            return;
        balance -= Time.deltaTime * RateOfDecay;

        if(balance < 0){
            
        }

    }
}
