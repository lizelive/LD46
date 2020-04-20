using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour
{

    public SoundEvent sound;

    void OnCollisionEnter(Collision collision)
    {
        var food = collision.collider.GetComponentInParent<Garbage>()?.gameObject;
        
        if(food){
            Destroy(food);
            sound?.Play(transform.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
