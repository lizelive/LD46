using Lowscope.Saving;
using System;
using System.Collections;
using System.Linq;

using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Newspaper : MonoBehaviour, ISaveable
{

    public static Newspaper I;

    Newspaper()
    {
        I = this;
    }

    public TextMeshProUGUI headline, winers, losers;

    [Serializable]
    class Data {
        public string headline;
        public Need failureCase;
        public List<string> winners = new List<string>();
        public List<string> losers = new List<string>();
    }
    
    Data data = new Data();

    public void Draw()
    {
        headline.text = data.headline;
        losers.text = "Losers: " + string.Join(", ", data.losers);
        winers.text = "Winners: " + string.Join(", ", data.winners);
    }

    public void Report(string username, Need failureCase, bool lost = true)
    {
        var newPlayer = !(data.winners.Contains(username) || data.losers.Contains(username));
        //var lost = failureCase == null;
        if (lost)
        {
            if (newPlayer)
            {
                data.losers.Add(username);
            }
            data.headline = $"{username} {failureCase.causeOfDeath} innocent plant";

        }
        else
        {
            if (newPlayer)
            {
                data.winners.Add(username);
            }

            data.headline = $"{username} takes care of plant";
        }
        Draw();
    }

    #region Save
    public string OnSave()
    {
        var newspaper = JsonUtility.ToJson(data);
        print(newspaper);
        return newspaper;
    }

    public void OnLoad(string data)
    {
        this.data= JsonUtility.FromJson<Data>(data);
        Draw();
    }

    // i don't care about this
    public bool OnSaveCondition()
    {
        return true;
    }
    #endregion
}
