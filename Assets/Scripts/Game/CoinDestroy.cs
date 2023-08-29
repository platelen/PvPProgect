using Events;
using Photon.Pun;
using UnityEngine;

namespace Game
{
    public class CoinDestroy : MonoBehaviour
    {
        [SerializeField] private int _addScore;
        private PhotonView _photonView;

        private void Start()
        {
            _photonView = GetComponent<PhotonView>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                //if (!_photonView.IsMine) return;
                GlobalEventsManager.SendAddingScore(_addScore);
                DestroyCoin();
            }
        }

        private void DestroyCoin()
        {
            if (_photonView.IsMine)
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}