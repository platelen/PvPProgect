using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _rotationSpeed = 100f;
        [SerializeField] private Joystick _joystick;

        private Animation _anim;
        private Vector2 _movement;
        private Rigidbody2D _rb;


        private void Start()
        {
            _joystick = FindObjectOfType<Joystick>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_joystick.Horizontal > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (_joystick.Horizontal < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }

            // if (_joystick.Horizontal != 0)
            // {
            //     _anim.Play();
            // }
            // else
            // {
            //     _anim.Stop();
            // }

            Vector2 moveInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
            _movement = moveInput.normalized * _speed;
        }

        private void FixedUpdate()
        {
            _rb.MovePosition(_rb.position + _movement * Time.deltaTime);
        }
    }
}