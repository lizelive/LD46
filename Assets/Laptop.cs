using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour, IClickable
{
    enum OrderStatus
    {
        Waiting,
        Placed    
    }


    public Food[] possibleFood;

    public Transform deliveryLocation;
    
    
    public SoundEvent orderFood;
    public SoundEvent foodArived;

    public void Click(Player player)
    {
        orderFood?.Play(transform.position);
    }


    

}
