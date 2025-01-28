using System.Linq;
using Script.Core;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

   
    public float dollarsPerWatt;
    public BuyButton buyPrefab;
    public WattState wattState;
    public GameObject buyScroll;
    public GameObject buttonSroll;

    void Start() {
        InvokeRepeating("GenerateWatts", 1f, 1f);
        wattState.Dollars = 100;
        var width = 200;
        var height = 150;
        var powerProducers = wattState.AvailableItems.Where(x => x.WattsPerSecond > 0).OrderBy(x => x.BaseCost).ToList();
        var batteries = wattState.AvailableItems.Where(x => x.WattStorage > 0).OrderBy(x => x.BaseCost).ToList();
        for (var index = 0; index < powerProducers.Count; index++) {
            var item =powerProducers[index];
            var btn = Instantiate(buyPrefab, buyScroll.transform);
            btn.gameObject.transform.localPosition += new Vector3(0, (-index * height) + 25, 0);
            //set width and height of button
            var rect = btn.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(width, height);
            rect.anchorMax = new Vector2(0.5f, 1);
            rect.anchorMin = new Vector2(0.5f, 1);
            rect.pivot = new Vector2(0.5f, 1);
            
            btn.SetupItem(item);
        }
        for (var index = 0; index < batteries.Count; index++) {
            var item = batteries[index];
            var btn = Instantiate(buyPrefab, buttonSroll.transform);
            btn.gameObject.transform.localPosition += new Vector3(0, -index * height, 0);
            //set width and height of button
            btn.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
            
            btn.SetupItem(item);
        }
    }
    
    void GenerateWatts() {
        wattState.TotalWatts += wattState.wattsPerSecond;

        if (wattState.TotalWatts > 0) {
            var toSubtract = (ulong)(wattState.consumptionPerSecond < wattState.TotalWatts ? wattState.consumptionPerSecond : wattState.TotalWatts);
            wattState.Dollars += (ulong)(toSubtract * dollarsPerWatt);
            wattState.TotalWatts -= toSubtract;
            wattState.townPopulaton += (float)toSubtract / 100;
        }

        if (wattState.TotalWatts > wattState.MaxStorageWatts) {
            wattState.TotalWatts = wattState.MaxStorageWatts;
        }
    }
    
}