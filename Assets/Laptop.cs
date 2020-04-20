using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour, IClickable
{
    public Food[] possibleFood;
    public SoundEvent orderFood;
    public SoundEvent foodArived;


    public float deliveryCountdown = float.PositiveInfinity;

    void Update()
    {
        if ((deliveryCountdown -= Time.deltaTime) <= 0)
        {
            var deliveryLocation = GameObject.FindGameObjectsWithTag("Delivery").Choice().transform;


            foodArived?.Play(transform.position);
            var food = Instantiate(possibleFood.Choice(), deliveryLocation.position, deliveryLocation.rotation);
            deliveryCountdown = float.PositiveInfinity;
        }
    }


    public void Click(Player player)
    {
        deliveryCountdown = Random.Range(5, 30);
        orderFood?.Play(transform.position);
    }
}
