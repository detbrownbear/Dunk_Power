using System;
using System.Numerics;
using Script.Core;
using TMPro;
using UnityEngine;

public class WattLabel : MonoBehaviour  {
    [SerializeField]
    private WattState wattState;
    private TMP_Text _label;

    void Awake() {
        _label = GetComponent<TMP_Text>();
    }
    private void Start() {
        UpdateLabel(wattState.TotalWatts);
    }

    private void OnEnable() {
        wattState.OnTotalWattsChanged += UpdateLabel;
        wattState.OnMaxStorageWattsChanged += UpdateLabel;
    }
    
    private void OnDisable() {
        wattState.OnTotalWattsChanged -= UpdateLabel;
        wattState.OnMaxStorageWattsChanged -= UpdateLabel;
    }

    private void UpdateLabel(BigInteger obj) {
        _label.text = $"Watts: {wattState.TotalWatts}W / {wattState.MaxStorageWatts}W";
    }
}
