using UnityEngine;


[CreateAssetMenu(fileName = "Sound", menuName = "Data/Sound", order = 1)]

public class Sound:ScriptableObject
{
    public AudioClip clip;
    public float weight;
    public float pitch;
    public float volume;
}