using System;
using Events;
using UnityEngine;
using UnityEngine.UI;

namespace Bullet
{
    public class StartBullet : MonoBehaviour
    {
        [SerializeField] private Button _buttonFire;

        private void Start()
        {
            _buttonFire.onClick.AddListener(GlobalEventsManager.SendStartBullet);
        }
    }
}