using System.Collections;
using System.Collections.Generic;
using Lowscope.Saving;
using UnityEngine;

public class Glass : MonoBehaviour, ISaveable
{

    public Transform waterTransform;
    public float balance;
    public float pourRate = 1;


    public void Add(float v)
    {
        balance = Mathf.Clamp01(balance + v);
    }
    // Update is called once per frame
    void Update()
    {

        var scale = Vector3.one;
        scale.z = balance;

        waterTransform.localScale = scale;

        var angle = Vector3.Angle(Vector3.up, transform.up);

        if(angle>45){
            Add(-Mathf.Min(balance, pourRate * Time.deltaTime));
        }

        if (Physics.Raycast(transform.position, Vector3.down, out var hit))
        {
            var plant = hit.collider.GetComponentInParent<Plant>();
            if (plant)
            {
                var transfer = Mathf.Min(balance, pourRate * Time.deltaTime);
                Add(-transfer);
                plant.Water(balance);
            }
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
