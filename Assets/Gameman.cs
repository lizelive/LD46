using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lowscope.Saving;
public class Gameman : MonoBehaviour
{
    public float maxITime = 30;

    public float iTime = 30;

    public GameObject IFrameUI;

    private bool isUIActive;

    // Start is called before the first frame update
    void Start()
    {
        isUIActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        var allTheNeeds = GameObject.FindObjectsOfType<Needy>();

        iTime-= Time.deltaTime;
        var freeze = iTime > 0;
        var failed = false;

        foreach (var need in allTheNeeds)
        {
            need.Freeze = freeze;

            if (!freeze && need.balance <= 0)
            {
                failed = true;
            }
        }

        if (!freeze && failed)
        {
            SaveMaster.SyncLoad();
            iTime = maxITime;
            this.isUIActive = true;
            this.IFrameUI.SetActive(true);
        }
        else if(!freeze && this.isUIActive){
            this.isUIActive = false;
            this.IFrameUI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.F5)){
            SaveMaster.SyncSave();
        }
        if(Input.GetKeyDown(KeyCode.F9)){
            SaveMaster.SyncLoad();
        }
    }
}
