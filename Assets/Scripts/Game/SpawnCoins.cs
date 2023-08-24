using System;
using System.Collections;
using Events;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class SpawnCoins : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject _prefabCoin;
        [SerializeField] private float _intervalSpawn;
        [SerializeField] private float _spawnAreaX;
        [SerializeField] private float _spawnAreaY;

        private void Awake()
        {
            GlobalEventsManager.OnVictoryCoin.AddListener(StoppingAfterVictory);
        }

        private void Start()
        {
            StartCoroutine(SpawningCoins());
        }

        private IEnumerator SpawningCoins()
        {
            yield return new WaitForSeconds(0);
            while (true)
            {
                PhotonNetwork.Instantiate(_prefabCoin.name, RandomSpawnPos(), Quaternion.identity);
                yield return new WaitForSeconds(_intervalSpawn);
            }
        }

        private void StoppingAfterVictory()
        {
            StopAllCoroutines();
        }

        private Vector3 RandomSpawnPos()
        {
            return new Vector3(Random.Range(-_spawnAreaX, _spawnAreaX), Random.Range(-_spawnAreaY, _spawnAreaY));
        }
    }
}