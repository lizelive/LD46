using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedViz : MonoBehaviour
{
    public GameObject prefab;
    public GameObject target;

    public Need need;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.handleRect.GetComponent<RawImage>().texture = need.icon;
        slider.fillRect.GetComponentInChildren<Image>().color = need.color;
    }

    // Update is called once per frame
    void Update()
    {
        var needy = target.GetNeedy(need);
        if(!needy)
            return;
        slider.value = (needy.balance / needy.maxValue);
    }
}
