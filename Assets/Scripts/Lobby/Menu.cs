using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace Lobby
{
    public class Menu : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField _inputRoomName;

        public void CreateRoom()
        {
            string roomName = _inputRoomName.text;
            RoomOptions roomOptions = new RoomOptions
            {
                MaxPlayers = 5
            };
            PhotonNetwork.CreateRoom(roomName, roomOptions, TypedLobby.Default);
        }

        public void JoinRandomRoom()
        {
            string roomName = _inputRoomName.text;
            PhotonNetwork.JoinRoom(roomName);
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel("Game");
            Debug.Log("Connected to room");
        }
    }
}