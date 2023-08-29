using System.Collections;
using Events;
using Photon.Pun;
using UnityEngine;

namespace Game
{
    public class CoinDestroy : MonoBehaviour
    {
        [SerializeField] private int _addScore;
        [SerializeField] private float _destroyDelay = 5f;

        private PhotonView _photonView;

        private void Start()
        {
            _photonView = GetComponent<PhotonView>();
            StartCoroutine(DestroyObjectAfterDelay());
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

        private IEnumerator DestroyObjectAfterDelay()
        {
            yield return new WaitForSeconds(_destroyDelay);
            if (_photonView.IsMine)
            {
                PhotonNetwork.Destroy(gameObject);
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