using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameSystem : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _spawn;

    public void Start()
    {
        PhotonNetwork.Instantiate(_player.name,
            new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f)),
            Quaternion.identity);
    }
}