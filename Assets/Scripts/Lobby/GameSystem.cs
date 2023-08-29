using Photon.Pun;
using UnityEngine;

namespace Lobby
{
    public class GameSystem : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject _player;

        public void Start()
        {
            PhotonNetwork.Instantiate(_player.name,
                new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f)),
                Quaternion.identity);
        }
    }
}