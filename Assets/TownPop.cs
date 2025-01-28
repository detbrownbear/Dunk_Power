using Script.Core;
using TMPro;
using UnityEngine;

public class TownPop : MonoBehaviour {
    private TMP_Text _powerUsageText;
    public WattState wattState;

    private void Awake() {
        _powerUsageText = GetComponent<TMP_Text>();
    }

    private void Update() {
        _powerUsageText.text = $"Town Pop: {wattState.townPopulaton:0}";
    }
}