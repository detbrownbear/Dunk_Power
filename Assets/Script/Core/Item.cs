using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Core {
    [CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 2)]
    public class Item : ScriptableObject {
        public string Name;
        public ulong BaseCost;
        public ulong WattsPerSecond;
        public ulong WattStorage;
        public ulong PurchasedCount;
        public float IncreasePerPurchase = 1.15f;
        
        public ulong ActualPrice => (ulong)(BaseCost * (Mathf.Pow(IncreasePerPurchase, PurchasedCount)));
    }
}