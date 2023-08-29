using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Events
{
    public class CoinBar : MonoBehaviour
    {
        [SerializeField] private WorkingWithCoins _workingWithCoins;
        [SerializeField] private Slider _coinBar;

        private PhotonView _photonView;
        private float _syncValue;
        
        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
        }

        // private void Start()
        // {
        //     if (_photonView.IsMine)
        //     {
        //         //_coinBar.interactable = false;
        //     }
        // }

        private void Update()
        {
            if (_coinBar.value >= _workingWithCoins.VictoryCoin)
            {
               GlobalEventsManager.SendVictoryCoin();
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