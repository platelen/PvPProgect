using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

namespace Lobby
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField _inputRoomName;
        [SerializeField] private Button _createRoomButton;
        [SerializeField] private Button _joinRoomButton;
        [SerializeField] private TextMeshProUGUI _textLog;

        private string _gameVersion;

        private void Start()
        {
            PhotonNetwork.NickName = "Player" + Random.Range(1000, 9999);
            Log("Player's name is set to " + PhotonNetwork.NickName);
            
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = "1";
            PhotonNetwork.ConnectUsingSettings();

            _createRoomButton.onClick.AddListener(CreatedRoom);
            _joinRoomButton.onClick.AddListener(JoiningRoom);
        }

        public override void OnConnectedToMaster()
        {
            Log("Connected to Master");
        }

        private void Log(string message)
        {
            Debug.Log(message);
            _textLog.text += "\n";
            _textLog.text += message;
        }

        private void CreatedRoom()
        {
            string roomName = _inputRoomName.text;
            PhotonNetwork.CreateRoom(roomName);
        }

        private void JoiningRoom()
        {
            string roomName = _inputRoomName.text;
            PhotonNetwork.JoinRoom(roomName);
        }

        public override void OnCreatedRoom()
        {
            Log("Room created: " + PhotonNetwork.CurrentRoom.Name);
        }

        public override void OnJoinedRoom()
        {
            Log("Joined room: " + PhotonNetwork.CurrentRoom.Name);
            PhotonNetwork.LoadLevel("Game");
        }
    }
}