using Assets.Scripts.Datas;
using Assets.Scripts.Input;
using Reflex.Attributes;
using UnityEngine;
using System;

namespace Assets.Scripts.Player.Move
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour, IMoveble, IDisposable
    {
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private Transform _characterModel;

        private Rigidbody _rigidbody;
        private PlayerInput _playerInput;
        private IInput _input;

        public Transform CharacterModel => _characterModel;

        private void Awake()
        {
            _characterModel = transform;
            _rigidbody = GetComponent<Rigidbody>();

            //((IMoveble)this).transform.position = Vector3.back;
        }

        [Inject]
        public void Construct(IInput input, PlayerInput playerInput)
        {
            _input = input;
            _playerInput = playerInput;
            _playerInput.Enable();
            _input.Moved += OnMove;
            _input.Stopped += StopMove;
        }

        public void Dispose()
        {
            _playerInput.Disable();
            _input.Moved -= OnMove;
            _input.Stopped -= StopMove;
        }

        public void OnMove(Vector3 direction)
        {
            _characterModel.LookAt(_characterModel.position + direction);
            _rigidbody.velocity = direction * _characterConfig.Speed * _characterConfig.SpeedRate;

            _characterView.StartWalk();
            _characterView.StopIdle();
        }

        public void StopMove()
        {
            if (_rigidbody != null)
                _rigidbody.velocity = Vector3.zero;

            _characterView.StartIdle();
            _characterView.StopWalk();
        }
    }
}