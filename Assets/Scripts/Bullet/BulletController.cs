using System;
using UnityEngine;

namespace Bullet
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float _speedBullet;
        [SerializeField] private float _damageBullet;

        private void Update()
        {
            MoveBullet();
        }

        private void MoveBullet()
        {
            Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
            rb2D.velocity = new Vector2(_speedBullet, 0);
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}