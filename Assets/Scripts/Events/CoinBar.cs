using System;
using UnityEngine;
using UnityEngine.UI;

namespace Events
{
    public class CoinBar : MonoBehaviour
    {
        [SerializeField] private WorkingWithCoins _workingWithCoins;
        [SerializeField] private Slider _coinBar;

        private void Update()
        {
            if (_coinBar.value >= _workingWithCoins.VictoryCoin)
            {
                Debug.Log("Victory");
            }
        }

        public void SetCurrentBar(int coin)
        {
            _coinBar.value = coin;
        }

        public void SetMaxCurrent(int coin)
        {
            _coinBar.maxValue = coin;
            _coinBar.value = coin;
        }
    }
}