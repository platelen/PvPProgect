using System.Collections;
using Player;
using UnityEngine;

namespace Bullet
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private int _damageBullet = 10;
        [SerializeField] private float _destroyDelay = 3f;


        private void Start()
        {
            //StartCoroutine(DestroyObjectAfterDelay());
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
                HealthPlayer healthPlayer = col.gameObject.GetComponent<HealthPlayer>();
                if (healthPlayer != null)
                {
                    Debug.Log("Работаем");
                    healthPlayer.TakeDamage(_damageBullet);
                }

                Destroy(gameObject);
            }
        }
    }
}