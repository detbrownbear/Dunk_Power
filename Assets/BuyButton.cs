using System;
using System.Numerics;
using Script.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour  {
    private Item _item;
    
    [SerializeField]
    private WattState wattState;
    private TMP_Text buttonText;
    private Button _button;
    
    
    void Awake() {
        buttonText = GetComponentInChildren<TMP_Text>();
        _button = GetComponent<Button>();
    }

    private void Start() {
        wattState.OnDollarsChanged += UpdateEnabled;
    }

    private void UpdateEnabled(ulong obj) {
        _button.interactable = wattState.Dollars >= _item.ActualPrice;
    }

    public void SetupItem(Item item) {
        _item = item;
        UpdateButtonText();
    }

    private void UpdateButtonText() {
        var wps = _item.WattsPerSecond > 0 ? $"+{_item.WattsPerSecond} W/s" : "";
        var ws = _item.WattStorage > 0 ? $"+{_item.WattStorage} W" : "";
        buttonText.text = @$"{_item.Name} (${_item.ActualPrice})
{wps}
{ws}";
    }
    

    public void OnButtonClick() {
        if(wattState.Dollars >= _item.ActualPrice) {
            wattState.Dollars -= _item.ActualPrice;
            wattState.wattsPerSecond += _item.WattsPerSecond;
            wattState.MaxStorageWatts += _item.WattStorage;
            _item.PurchasedCount++;
            UpdateButtonText();
        }
    }
}
