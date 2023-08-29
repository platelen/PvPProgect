using System;
using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class HealthPlayer : MonoBehaviour
    {
        [SerializeField] private HpBar _hpBar;
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _currentHealth;

        [SerializeField] private PhotonView _photonView;


        private void Start()
        {
            _currentHealth = _maxHealth;
            _hpBar.SetMaxHealth(_maxHealth);
        }

        private void Update()
        {
            KilledPlayer();
        }

        public void TakeDamage(int damage)
        {
            _photonView.RPC("TakeDamageRPC", RpcTarget.All, damage);
        }

        [PunRPC]
        public void TakeDamageRPC(int damage)
        {
            _currentHealth -= damage;
            _hpBar.SetHpBar(_currentHealth);
        }

        private void KilledPlayer()
        {
            if (_currentHealth <= 0)
            {
                if (_photonView.IsMine)
                    PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}