using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnYeet : MonoBehaviour
{

    public Transform deliveryLocation;

    // Start is called before the first frame update
    void Start()
    {
        deliveryLocation = GameObject.FindGameObjectsWithTag("Delivery").Choice().transform;
    }

    // Update is called once per frame
    void Update()
    {
        var badObjects = UnityEngine.Object.FindObjectsOfType<GameObject>().Where(obj => obj.transform.parent == null && obj.transform.position.y < -100);
        if (badObjects != null)
        {
            foreach (var miscreant in badObjects)
            {
                var rigidbodies = miscreant.GetComponentsInChildren<Rigidbody>();

                if (rigidbodies != null)
                {
                    foreach (var rigidbody in rigidbodies)
                    {
                        rigidbody.velocity = new Vector3();
                    }
                }

                miscreant.transform.position = deliveryLocation.position;
            }
        }
    }
}