using System;
using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class SwapSpriteCharacter : MonoBehaviour
    {
        [SerializeField] private PhotonView _photonView;
        [SerializeField] private Sprite _otherPlayerSprites;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            if (!_photonView.IsMine) _spriteRenderer.sprite = _otherPlayerSprites;
        }
    }
}