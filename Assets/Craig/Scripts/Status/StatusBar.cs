using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Status {
   
    public class StatusBar : MonoBehaviour {

        public Needy Need;
 
        public const float MaxCapacity = 100;
 
        public float CurrentCapacity {get; private set; }
 
        public bool BarIsEmpty { get { return CurrentCapacity <= 0; } }
 
        public float CapacityDecayRate;

        public Color StatusBarColor;

        private Slider statusBarSlider;

        private const float backgroundColorMultiplier = 0.6f;

        // Used for overriding the state of the status bar - ie, if the game is reverted to a prior state.
        public void SetStatusBarState(float currentCapacity, float capacityDecayRate){
            this.CurrentCapacity = currentCapacity;
            this.CapacityDecayRate = capacityDecayRate;
            this.UpdateStatusBarSlider();
        }
 
        void Start(){
            this.CurrentCapacity = MaxCapacity;
            this.statusBarSlider = gameObject.GetComponentInChildren<Slider>();
            this.statusBarSlider.gameObject.transform.Find("FillArea/Fill").GetComponent<Image>().color = this.StatusBarColor;
            this.statusBarSlider.gameObject.transform.Find("Background").GetComponent<Image>().color = backgroundColorMultiplier * this.StatusBarColor;
        }

        private void UpdateStatusBarSlider(){
            this.statusBarSlider.value = (this.CurrentCapacity / MaxCapacity);
        }

        void Update(){
            this.UpdateStatusBarSlider();
        }
 
        public void DecayCapacity()
        {
            this.CurrentCapacity = Mathf.Max(this.CurrentCapacity - Time.deltaTime * this.CapacityDecayRate, 0);
        }
 
        // Restores capacity to the bar. Does not support overfilling.
        // If the input refill amount is null, the bar is restored to its maximum capacity.
        public void RestoreCapacity(float? refillAmount = null)
        {
            float resolvedRefillAmount = refillAmount ?? MaxCapacity;
            this.CurrentCapacity = Mathf.Min(MaxCapacity, this.CurrentCapacity + resolvedRefillAmount);
        }
    }
}