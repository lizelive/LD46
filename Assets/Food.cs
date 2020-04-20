using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : ClickNeedProvider
{
    public Garbage ate, spoiled;

    public float spoilCounter = 100;

    public override void Click(Player player)
    {
        base.Click(player);
        Instantiate(ate, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spoilCounter -= Time.deltaTime;
        if(spoilCounter <= 0 )
        {
            Destroy(gameObject);
            Instantiate(spoiled, transform.position, transform.rotation);
        }
    }
}
