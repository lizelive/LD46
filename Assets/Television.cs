using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Television : MonoBehaviour
{
    public Need need;
    public float rate;
    public Material material;
    public SoundEvent sound;
    public float range = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindObjectOfType<Player>();
        var dist = Vector3.Distance(player.transform.position, transform.position);
        

        var inRange  =dist < range;
        var active = inRange && player.LookingAt(transform.position); 

        if(inRange){
            material.color = Color.white;
            sound?.Play(transform.position);
        }
        else{
            material.color = Color.black;

        }

        if(active){
            player.Satisfy(need, rate * Time.deltaTime);
        }

    }
}
