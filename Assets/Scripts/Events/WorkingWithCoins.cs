using System;
using TMPro;
using UnityEngine;

namespace Events
{
    public class WorkingWithCoins : MonoBehaviour
    {
        [SerializeField] private CoinBar _coinBar;
        [SerializeField] private int _victoryCoin;
        private int _intScore;

        public int VictoryCoin => _victoryCoin;


        private void Awake()
        {
            GlobalEventsManager.OnAddingScore.AddListener(AddingScore);
        }

        private void AddingScore(int addingScore)
        {
            _intScore += addingScore;   
            _coinBar.SetCurrentBar(_intScore);
            GetComponent<TextMeshProUGUI>().text = "Coins: " + _intScore;
        }
    }
}