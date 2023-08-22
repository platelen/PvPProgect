using System.Collections;
using UnityEngine;

namespace Bullet
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float _damageBullet;
        [SerializeField] private float _destroyDelay = 3f;

        private void Start()
        {
            StartCoroutine(DestroyObjectAfterDelay());
        }

        private IEnumerator DestroyObjectAfterDelay()
        {
            yield return new WaitForSeconds(_destroyDelay);
            Destroy(gameObject);
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