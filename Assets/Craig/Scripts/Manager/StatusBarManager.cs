using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
 
using Game.Status;
 
namespace Game.Manager {
   
    public class StatusBarManager : MonoBehaviour {
 
        public List<StatusBar> statusBarsInit;
 
        public Dictionary<NeedEnum, StatusBar> StatusBars { get; private set; }
 
        public int StartingInvincibilityFrames;
 
        public int InvincibilityFrames { get; private set; }
 
        public static Dictionary<NeedEnum, CauseOfDeath> DeathFromNeed = new Dictionary<NeedEnum, CauseOfDeath>
        {
            { NeedEnum.None, CauseOfDeath.None },
            { NeedEnum.Food, CauseOfDeath.Starvation },
            { NeedEnum.Water, CauseOfDeath.Dehydration },
            { NeedEnum.Sleep, CauseOfDeath.Exhaustion },
            { NeedEnum.Hygiene, CauseOfDeath.Disease },
            { NeedEnum.Cleanliness, CauseOfDeath.Disease },
            { NeedEnum.Entertainment, CauseOfDeath.Boredom },
            { NeedEnum.WaterPlant, CauseOfDeath.PlantDied },
            { NeedEnum.SunPlant, CauseOfDeath.PlantDied },
        };
 
        // Use this for initialization
        void Start () {
            this.InvincibilityFrames = StartingInvincibilityFrames;
            this.InitializeStatusBarMap();
        }
 
        private void InitializeStatusBarMap(){
            // Linq ToDictionary isn't resolving :/.
            // this.StatusBars = this.statusBarsInit.ToDictionary<NeedEnum, StatusBar>(x => x.NeedEnum);
            this.StatusBars = new Dictionary<NeedEnum, StatusBar>();
            foreach (var statusBar in this.statusBarsInit) {
                this.StatusBars.Add (statusBar.Need, statusBar);
            }
 
            this.statusBarsInit = null;
        }
 
        // Update is called once per frame
        void Update () {
 
            /*
            if (PlayerMaanger.PlayerIsDead){
                return;
            }
            */
 
            if (this.InvincibilityFrames > 0) {
                this.InvincibilityFrames--;
            } else {
                foreach (var statusBar in this.StatusBars.Values) {
                    statusBar.DecayCapacity();
                }
 
                var causeOfDeath = this.GetCauseOfDeath();
                if (causeOfDeath != CauseOfDeath.None)
                {
                    // PlayerManager.ReportDeath();
                }
            }
        }
 
        public CauseOfDeath GetCauseOfDeath() {
            foreach (var statusBar in this.StatusBars.Values) {
                if (statusBar.BarIsEmpty) {
                    return DeathFromNeed[statusBar.Need];
                }
            }
 
            return CauseOfDeath.None;
        }
 
        // Restores capacity to the bar matching the input need. Does not support overfilling.
        // If the input refill amount is null, the bar is restored to its maximum capacity.
        public void RestoreStatusBarCapacity(NeedEnum need, float? refillAmount) {
            if (this.StatusBars.TryGetValue(need, out var statusBar)) {
                statusBar.RestoreCapacity(refillAmount);
            }
        }
    }

    }

