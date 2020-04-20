using System;
using System.Collections;
using System.Collections.Generic;
using Lowscope.Saving;
using UnityEngine;

public class Needy : MonoBehaviour, ISaveable
{



    public bool Freeze;
    public Need need;
    public float balance = 50;
    public float maxValue = 100;
    public float baseRateOfDecay = 1;
    public float RateOfDecay => baseRateOfDecay;

    public float lowThreshold = 0.3f;

public SoundEvent thankYou;

    public void Add(float ammount){
        if(ammount>0){
            thankYou?.Play(transform.position);
        }

        balance =  Mathf.Min(balance + ammount, maxValue); 
    }

    void Update(){
        if(Freeze)
            return;
        balance -= Time.deltaTime * RateOfDecay;

        if(balance < 0){
            
        }

    }

    #region Save
    [System.Serializable]
    public struct SaveData
    {
        public float balance;
    }
    public string OnSave()
    {
        return JsonUtility.ToJson(new SaveData() { balance = this.balance });
    }

    public void OnLoad(string data)
    {
        var save = JsonUtility.FromJson<SaveData>(data);
        balance = save.balance;
    }
    
    
    // i don't care about this
    public bool OnSaveCondition()
    {
        return true;
    }
    #endregion
}
