using System;
using Script.Core;
using UnityEngine;

public class MoneyText : MonoBehaviour {
    [SerializeField]
    private WattState wattState;
    private TMPro.TMP_Text _label;

    void Awake() {
        _label = GetComponent<TMPro.TMP_Text>();
    }
    private void Start() {
        UpdateLabel(wattState.Dollars);
    }

    private void OnEnable() {
        wattState.OnDollarsChanged += UpdateLabel;
    }
    
    private void OnDisable() {
        wattState.OnDollarsChanged -= UpdateLabel;
    }

    private void UpdateLabel(float dollars) {
        _label.text = $"Money: ${wattState.Dollars}";
    }

}
