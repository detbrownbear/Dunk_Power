using UnityEngine;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Script.Core {

    [CreateAssetMenu(fileName = "WattState", menuName = "ScriptableObjects/WattState", order = 1)]
    public class WattState : ScriptableObject {
        public event Action<BigInteger> OnTotalWattsChanged;
        public event Action<BigInteger> OnMaxStorageWattsChanged;
        public event Action<ulong> OnDollarsChanged;

        private ulong _totalWatts;
        private ulong _maxStorageWatts;
        private ulong _dollars;

        public ulong wattsPerSecond;
        public List<Item> AvailableItems;
        public double consumptionPerSecond => townPopulaton * GetTimeofdayModifier * consumptionPerPopulaton;
        public double townPopulaton = 100;
        public double timeOfDay = 0;
        public double consumptionPerPopulaton = 1;
        private double GetTimeofdayModifier => Math.Sin(timeOfDay / 300) + 1f;
        
        public ulong TotalWatts {
            get => _totalWatts;
            set {
                if (_totalWatts != value) {
                    _totalWatts = value;
                    OnTotalWattsChanged?.Invoke(_totalWatts);
                }
            }
        }

        public ulong MaxStorageWatts {
            get => _maxStorageWatts;
            set {
                if (_maxStorageWatts != value) {
                    _maxStorageWatts = value;
                    OnMaxStorageWattsChanged?.Invoke(_maxStorageWatts);
                }
            }
        }

        public ulong Dollars {
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