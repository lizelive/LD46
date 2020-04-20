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



    public static void Satisfy(this GameObject self, Need need, float amount)
    {
        var needy = self.GetNeedy(need);
        if (needy)
        {
            needy.Add(amount);
        }
    }

    
    public static Needy GetNeedy(this GameObject self, Need need)
    {
        return self.GetComponentsInChildren<Needy>().FirstOrDefault(x => x.need == need);
    }

    public static void Satisfy(this Component self, Need need, float amount)
    {
        self.gameObject.Satisfy(need, amount);
    }

    
    public static Needy GetNeedy(this Component self, Need need)
    {
        return self.gameObject.GetNeedy(need);
    }
}


public interface IWeighted
{
    float Weight { get; }
}