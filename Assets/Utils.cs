using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
