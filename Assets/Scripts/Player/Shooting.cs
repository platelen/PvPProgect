using System;
using Events;
using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class Shooting : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _startBullet;
        [SerializeField] private float _bulletForce;

        private PhotonView _photonView;
        private bool _isShoot;

        private void Awake()
        {
            GlobalEventsManager.OnStartBullet.AddListener(StartBullet);
        }

        private void Start()
        {
            _photonView = GetComponent<PhotonView>();
        }

        private void Update()
        {
            if (_isShoot == true)
            {
                StartBullet();
            }
        }

        private void StartBullet()
        {
            if (!_photonView.IsMine) return;
            _isShoot = true;
            GameObject bullet = PhotonNetwork.Instantiate(_bullet.name, _startBullet.position, _startBullet.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(_startBullet.right * _bulletForce, ForceMode2D.Impulse);
            _isShoot = false;
        }
    }
}