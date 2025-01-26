using Script.Core;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int consumptionPerSecond;
    public float dollarsPerWatt;
    
    public WattState wattState;

    void Start() {
        InvokeRepeating("GenerateWatts", 1f, 1f);
        wattState.Dollars = 100;
    }
    
    void GenerateWatts() {
        wattState.TotalWatts += wattState.wattsPerSecond;

        if (wattState.TotalWatts > 0) {
            var toSubtract = consumptionPerSecond < wattState.TotalWatts ? consumptionPerSecond : wattState.TotalWatts;
            wattState.Dollars += (ulong)toSubtract * dollarsPerWatt;
            wattState.TotalWatts -= toSubtract;
        }

        if (wattState.TotalWatts > wattState.MaxStorageWatts) {
            wattState.TotalWatts = wattState.MaxStorageWatts;
        }
    }
    
}