using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipbookRender : MonoBehaviour
{
    private int frame;
    public Material material;
    public FlipbookTexture texture;

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount %  texture.ticksPerFrame == 0)
        {
            frame = (frame + 1) % texture.frames.Length;
            material.mainTexture = texture.frames[frame];
        }
    }
}
