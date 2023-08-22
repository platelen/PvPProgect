using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Button _buttonLeave;


        void Start()
        {
            _buttonLeave.onClick.AddListener(LeaveRoom);
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