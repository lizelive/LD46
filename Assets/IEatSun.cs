using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IEatSun : MonoBehaviour
{
    public float lightValue;

    public ParticleSystem sunParticles;

    public LayerMask layerMask;
    public float sunlightNeed = 0.7f;

    public float sunWeight = 100f;
    public float minDist = 0.2f;
    public float maxDist = 1000;


    public Needy need;

    public SoundEvent thankYou;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


        var iEats = 0f;
        var sun = RenderSettings.sun;
        var castDir = -sun.transform.forward;

        var start = transform.position + castDir * minDist;
        var end = start + castDir * maxDist;
        var inSun = !Physics.Raycast(start, castDir, maxDist, layerMask.value);
        if (inSun)
        {
            iEats += sun.intensity * sunWeight;

        }
        else
        {
            Debug.DrawLine(start, end, Color.red);

        }
        
        var emission = sunParticles.emission;
        emission.enabled = inSun;

        LightProbes.GetInterpolatedProbe(transform.position, null, out var sh2);
        var dirs = new[] { Vector3.down, Vector3.up, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };
        var colors = new Color[dirs.Length];
        sh2.Evaluate(dirs, colors);
        iEats += colors.Average(it => it.grayscale);

        if (lightValue + 0.04f < iEats)
        {
            thankYou?.Play(transform.position);
        }
        
        need.Add(iEats * Time.deltaTime);

        lightValue = iEats;
    }
}
