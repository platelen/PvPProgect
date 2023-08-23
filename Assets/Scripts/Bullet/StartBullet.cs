using Events;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Bullet
{
    public class StartBullet : MonoBehaviour
    {
        [SerializeField] private Button _buttonFire;

        private PhotonView _photonView;
        
        private void Start()
        {
            _photonView = GetComponent<PhotonView>();
            //if (!_photonView.IsMine) return;
            _buttonFire.onClick.AddListener(GlobalEventsManager.SendStartBullet);
        }

        private void Update()
        {
            if (!_photonView.IsMine) return;
        }
    }
}