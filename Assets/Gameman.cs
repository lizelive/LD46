using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lowscope.Saving;
public class Gameman : MonoBehaviour
{
    

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        var allTheNeeds = GameObject.FindObjectsOfType<Needy>();

        var failed = false;

        foreach (var need in allTheNeeds)
        {
            if(need.balance <= 0)
            {
                failed = true;
                SaveMaster.SyncLoad();
            }
        }


        if(Input.GetKeyDown(KeyCode.F5)){
            SaveMaster.SyncSave();
        }
        if(Input.GetKeyDown(KeyCode.F9)){
            SaveMaster.SyncLoad();
        }
    }
}
