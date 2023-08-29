using System.Collections;
using Photon.Pun;
using Player;
using UnityEngine;

namespace Bullet
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private int _damageBullet = 10;
        [SerializeField] private float _destroyDelay = 3f;

        private PhotonView _photonView;

        private void Start()
        {
            _photonView = GetComponent<PhotonView>();
            StartCoroutine(DestroyObjectAfterDelay());
        }

        private IEnumerator DestroyObjectAfterDelay()
        {
            yield return new WaitForSeconds(_destroyDelay);
            PhotonNetwork.Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                HealthPlayer healthPlayer = col.gameObject.GetComponent<HealthPlayer>();
                if (healthPlayer != null)
                {
                    healthPlayer.TakeDamage(_damageBullet);
                }

                DestroyBullet();
            }
        }

        private void DestroyBullet()
        {
            if (_photonView.IsMine)
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}