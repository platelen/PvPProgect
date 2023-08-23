using Events;
using UnityEngine;

namespace Player
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _startBullet;
        [SerializeField] private float _bulletForce;

        private bool _isShoot;

        private void Awake()
        {
            GlobalEventsManager.OnStartBullet.AddListener(StartBullet);
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
            _isShoot = true;
            GameObject bullet = Instantiate(_bullet, _startBullet.position, _startBullet.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(_startBullet.right * _bulletForce, ForceMode2D.Impulse);
            _isShoot = false;
        }
    }
}