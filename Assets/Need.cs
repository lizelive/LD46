using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Need", menuName = "ScriptableObjects/Need", order = 1)]

public class Need : ScriptableObject
{
    public string causeOfDeath;
    public Texture2D icon;
    public Color color;
}
