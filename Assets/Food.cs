using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IClickable
{


    public float spoilCounter = 100;

    public void Click(Player player)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spoilCounter -= Time.deltaTime;
    }
}
