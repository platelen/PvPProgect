using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Joystick _joystick;


        private PhotonView _photonView;
        private Animation _anim;
        private Vector2 _movement;
        private Rigidbody2D _rb;

        private bool _isGame;

        private void Start()
        {
            _photonView = GetComponent<PhotonView>();
            _joystick = FindObjectOfType<Joystick>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!_photonView.IsMine) return;

            // if (PhotonNetwork.CountOfPlayersInRooms < 2)
            // {
            //     _isGame = false;
            // }
            // else if (PhotonNetwork.CountOfPlayersInRooms >= 2)
            // {
            //     _isGame = true;
            // }

            if (_joystick.Horizontal > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (_joystick.Horizontal < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }

            Vector2 moveInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
            _movement = moveInput.normalized * _speed;
        }

        private void FixedUpdate()
        {
            _rb.MovePosition(_rb.position + _movement * Time.deltaTime);
        }
    }
}