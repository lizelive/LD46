using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lowscope.Saving;
using UnityEngine.UI;

public class Gameman : MonoBehaviour
{
    public float maxITime = 30;

    public float iTime = 30;
    public Text currentlyPlaying;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        var allTheNeeds = GameObject.FindObjectsOfType<Needy>();


        iTime-= Time.deltaTime;

        if (!Inman.I.HasPlayer)
        {
            iTime = maxITime;
            currentlyPlaying.text = "Nobody ";
        }

        var playtime = Inman.I.HasPlayer ? Mathf.Max(Inman.I.playTime - (Time.time - Inman.I.joinTime), 0) : 0;
        var showName = Inman.I.HasPlayer ? Inman.I.username : "nobody";
        currentlyPlaying.text = $"{showName} is taking care of the plant and has {playtime}s of exlusive time"; 
        var freeze = iTime > 0;


        var failed = false;
        Need faileNeed = null;
        foreach (var need in allTheNeeds)
        {
            need.Freeze = freeze;

            if (!freeze && need.balance <= 0)
            {
                failed = true;
                faileNeed = need.need;
            }
        }
        failed &= !freeze;
        if (failed)
        {
            
            SaveMaster.SyncLoad();
            Newspaper.I.Report(Inman.I.username, faileNeed);
            Inman.I.RelinquishControl();
            iTime = maxITime;
        }

        if (Input.GetKeyDown(KeyCode.F5)){
            SaveMaster.SyncSave();
        }
        if(Input.GetKeyDown(KeyCode.F9)){
            SaveMaster.SyncLoad();
        }
    }
}
