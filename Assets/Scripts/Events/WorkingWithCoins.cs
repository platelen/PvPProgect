using System.Linq;
using Photon.Pun;
using TMPro;
using UnityEngine;

namespace Events
{
    public class WorkingWithCoins : MonoBehaviour
    {
        [SerializeField] private CoinBar _coinBar;
        [SerializeField] private int _victoryCoin;

        private int _intScore;
        private PhotonView _photonView;

        public int VictoryCoin => _victoryCoin;


        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
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