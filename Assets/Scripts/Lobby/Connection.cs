using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lobby
{
    public class Connection : MonoBehaviourPunCallbacks
    {
        void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to server, succesful!");
            SceneManager.LoadScene("Lobby");
        }
    }
}