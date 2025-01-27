using Script.Core;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int consumptionPerSecond;
    public float dollarsPerWatt;
    public BuyButton buyPrefab;
    public WattState wattState;
    public GameObject buttonPanel;

    void Start() {
        InvokeRepeating("GenerateWatts", 1f, 1f);
        wattState.Dollars = 100;
        var width = 200;
        var height = 100;
        for (var index = 0; index < wattState.AvailableItems.Count; index++) {
            var item = wattState.AvailableItems[index];
            var btn = Instantiate(buyPrefab, buttonPanel.transform);
            btn.gameObject.transform.localPosition += new Vector3(0, -index * height - 25, 0);
            //set width and height of button
            btn.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
            
            btn.SetupItem(item);
        }
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