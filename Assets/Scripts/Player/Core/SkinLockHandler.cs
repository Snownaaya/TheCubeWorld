using Assets.Scripts.Interfaces;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Player.Core
{
    public class SkinLockHandler : MonoBehaviour, ILockable
    {
        private CharacterFactory _characterFactory;

        public bool IsLock { get; private set; }

        [Inject]
        private void Construct(CharacterFactory characterFactory) =>
            _characterFactory = characterFactory;

        public void Lock()
        {
            IsLock = true;
            
        }

        public void Unlock()
        {

        }
    }
}