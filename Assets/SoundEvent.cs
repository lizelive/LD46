using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundEvent", menuName = "Data/SoundEvent", order = 1)]

public class SoundEvent : ScriptableObject
{

    public string subtitle;
    public Sound[] sounds;
}

