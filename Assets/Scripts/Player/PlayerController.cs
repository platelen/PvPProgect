using Events;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _startBullet;
        
        
        private void Awake()
        {
            GlobalEventsManager.OnStartBullet.AddListener(StartBullet);
        }

        private void StartBullet()
        {
            Instantiate(_bullet, _startBullet.position, Quaternion.identity);
        }
    }
}