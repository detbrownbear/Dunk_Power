using System.Numerics;
using Script.Core;
using TMPro;
using UnityEngine;

public class BuyButton : MonoBehaviour  {
    
    [SerializeField]
    private int cost;
    [SerializeField]
    private string itemName;
    [SerializeField]
    private ulong wattsPerSecond;
    [SerializeField]
    private ulong wattStorage;
    
    [SerializeField]
    private WattState wattState;
    private TMP_Text buttonText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        buttonText = GetComponentInChildren<TMP_Text>();
        UpdateButtonText();
    }

    private void UpdateButtonText() {
        var wps = wattsPerSecond > 0 ? $"{wattsPerSecond}W/s" : "";
        var ws = wattStorage > 0 ? $"{wattStorage}W" : "";
        buttonText.text = @$"{itemName}
 ${cost}
 {wps}
 {ws}";
    }
    

    public void OnButtonClick() {
        if(wattState.Dollars >= cost) {
            wattState.Dollars -= cost;
            wattState.wattsPerSecond += wattsPerSecond;
            wattState.MaxStorageWatts += wattStorage;
            UpdateButtonText();
        }
    }
}
