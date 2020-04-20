using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "SoundEvent", menuName = "Data/SoundEvent", order = 1)]

public class SoundEvent : ScriptableObject
{

    public string subtitle;
    public Sound[] sounds;


[System.NonSerialized]
private float nextPossiblePlayTime;
    public void Play(Vector3 position, float volume = 1, float pitch = 1){
        if(nextPossiblePlayTime > Time.time) return;
        var toPlay = GetSoundToPlay();

        if(!toPlay){
            return;
        }
        nextPossiblePlayTime= Time.time + toPlay.clip.length;
        AudioSource.PlayClipAtPoint(toPlay.clip, position, volume * toPlay.volume);
    }


    Sound GetSoundToPlay(){
        var total = sounds.Sum(x=>x.weight);
        var value = Random.value * total;

        foreach (var sound in sounds)
        {
            value-=sound.weight;
            if(value <= 0)
            return sound;
        }

        return null;

    }
}

