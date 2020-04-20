using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{

    public Need[] provides;
    public float rate = 1;
    public SoundEvent sound;

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
                    sound?.Play(transform.position);

        var ammountWaterGiven = Time.fixedDeltaTime * rate;


        var glass = other.GetComponentInParent<Glass>();
                      glass?.Add(ammountWaterGiven);
        
        foreach (var provide in provides)
        {
            other.Satisfy(provide, ammountWaterGiven);
        }
    }
}
