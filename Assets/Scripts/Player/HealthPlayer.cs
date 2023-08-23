using System;
using UnityEngine;

namespace Player
{
    public class HealthPlayer : MonoBehaviour
    {
        [SerializeField] private HpBar _hpBar;
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _currentHealth;

        private void Start()
        {
            _currentHealth = _maxHealth;
            _hpBar.SetMaxHealth(_maxHealth);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(20);
            }

            KilledPlayer();
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            _hpBar.SetHpBar(_currentHealth);
        }

        private void KilledPlayer()
        {
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}