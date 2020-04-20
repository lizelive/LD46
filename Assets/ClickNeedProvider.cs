using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickNeedProvider : MonoBehaviour, IClickable
{
    public Need need;
    public float value = 10;
    public float cooldownLength = 1;
    
    public float cooldownUntil;
    
    public SoundEvent sound;
    
    public virtual void Click(Player player)
    {
        var now = Time.time;
        if(cooldownUntil <= now){
            player.Satisfy(need, value);
            cooldownUntil = now + cooldownLength;

            sound?.Play(transform.position);
        }
    }
}
