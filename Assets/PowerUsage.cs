using System;
using Script.Core;
using TMPro;
using UnityEngine;

public class PowerUsage : MonoBehaviour {
    private TMP_Text _powerUsageText;
    public WattState wattState;
    private void Awake() {
        _powerUsageText = GetComponent<TMP_Text>();
        
    }

    private void Start() {
        InvokeRepeating("UpdateText", 1f, 1f);
    }

    private void UpdateText() {
        _powerUsageText.text = $"Power Usage: {wattState.consumptionPerSecond:0}w/s";
    }
  
}
