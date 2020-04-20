using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "flipbook", menuName = "Data/Flipbook Texture", order = 1)]

public class FlipbookTexture : ScriptableObject
{
    public int ticksPerFrame;
    public Texture2D[] frames;
}
