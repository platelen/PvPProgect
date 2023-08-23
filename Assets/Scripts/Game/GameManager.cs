using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Button _buttonLeave;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private float _spawnPlayerX;
        [SerializeField] private float _spawnPlayerY;

        void Start()
        {
            PhotonNetwork.Instantiate(_playerPrefab.name, RandomSpawnPos(), Quaternion.identity);
            _buttonLeave.onClick.AddListener(LeaveRoom);
        }

        private Vector3 RandomSpawnPos()
        {
            return new Vector3(Random.Range(-_spawnPlayerX, _spawnPlayerX),
                Random.Range(-_spawnPlayerY, _spawnPlayerY));
        }

        private void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            //Когда текущий игрок, покидает комнату.
            SceneManager.LoadScene("Lobby");
        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPLayer)
        {
            Debug.LogFormat("Player {0} entered room", newPLayer.NickName);
        }

        public override void OnPlayerLeftRoom(Photon.Realtime.Player newPLayer)
        {
            Debug.LogFormat("Player {0} left room", newPLayer.NickName);
        }
    }
}