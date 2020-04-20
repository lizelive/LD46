using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public float rate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void OnTriggerStay(Collider other)
    {
        var ammountWaterGiven = Time.fixedDeltaTime * rate;


        var glass = other.GetComponentInParent<Glass>();
                      glass?.Add(ammountWaterGiven);
        
        var plant = other.GetComponentInParent<Plant>();

        plant?.Water(ammountWaterGiven);

    }
}
