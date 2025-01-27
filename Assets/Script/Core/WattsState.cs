using UnityEngine;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Script.Core {

    [CreateAssetMenu(fileName = "WattState", menuName = "ScriptableObjects/WattState", order = 1)]
    public class WattState : ScriptableObject {
        public event Action<BigInteger> OnTotalWattsChanged;
        public event Action<BigInteger> OnMaxStorageWattsChanged;
        public event Action<float> OnDollarsChanged;

        private BigInteger _totalWatts;
        private BigInteger _maxStorageWatts;
        private float _dollars;

        public BigInteger wattsPerSecond;

        public List<Item> AvailableItems;
        public BigInteger TotalWatts {
            get => _totalWatts;
            set {
                if (_totalWatts != value) {
                    _totalWatts = value;
                    OnTotalWattsChanged?.Invoke(_totalWatts);
                }
            }
        }

        public BigInteger MaxStorageWatts {
            get => _maxStorageWatts;
            set {
                if (_maxStorageWatts != value) {
                    _maxStorageWatts = value;
                    OnMaxStorageWattsChanged?.Invoke(_maxStorageWatts);
                }
            }
        }

        public float Dollars {
            get => _dollars;
            set {
                if (_dollars != value) {
                    _dollars = value;
                    OnDollarsChanged?.Invoke(_dollars);
                }
            }
        }
    }
}