using UnityEngine;


[CreateAssetMenu(fileName = "Sound", menuName = "Data/Sound", order = 1)]

public class Sound:ScriptableObject, IWeighted
{
    public AudioClip clip;
    public float weight = 1;
    public float pitch = 1;
    public float volume = 1;

    public float Weight => weight;
}