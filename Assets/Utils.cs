using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Utils
{



    public static T Choice<T>(this IList<T> from)
    {
        return from[Random.Range(0, from.Count)];
    }

    public static Ray Ray(this Camera pov)
    {
        return new Ray(pov.transform.position, pov.transform.forward);
    }


    public static void Satisfy(this Component self, Need need, float amount)
    {
        var needy = self.GetComponentsInChildren<Needy>().FirstOrDefault(x => x.need == need);
        if (needy)
        {
            needy.Add(amount);
        }
    }
}


public interface IWeighted
{
    float Weight { get; }
}