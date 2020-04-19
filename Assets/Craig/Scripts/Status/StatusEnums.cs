using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace Game.Status {
   
    public enum Needy
    {
        None,
        Food,
        Water,
        Sleep,
        Hygiene,
        Cleanliness,
        Entertainment,
        WaterPlant,
        SunPlant,
    }
 
    public enum CauseOfDeath
    {
        None,
        Starvation,
        Dehydration,
        Exhaustion,
        Disease,
        Boredom,
        PlantDied,
    }
}