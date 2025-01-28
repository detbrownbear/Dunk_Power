using System;
using Script.Core;
using TMPro;
using UnityEngine;

public class TimeOfDay : MonoBehaviour {
    
    public WattState wattState;
    public float MinutesPerSecond = 60;
    private TMP_Text _timeText;

    private void Awake() {
        _timeText = GetComponent<TMP_Text>();
    }
    
    void Update() {
        wattState.timeOfDay += MinutesPerSecond * Time.deltaTime; 
       if (wattState.timeOfDay >= 1440) {
           wattState.timeOfDay -= 1440;
       }

       var min =  ((int)(Math.Floor(wattState.timeOfDay % 60) / 15)) * 15;
       _timeText.text = $"Time: {Math.Floor(wattState.timeOfDay / 60):00}:{min:00}";
       
    }
}
