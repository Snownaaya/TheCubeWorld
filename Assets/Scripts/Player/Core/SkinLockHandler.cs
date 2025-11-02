using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Player.Core
{
    public class SkinLockHandler : MonoBehaviour
    {
        private CharacterFactory _characterFactory;

        [Inject]
        private void Construct(CharacterFactory characterFactory) =>
            _characterFactory = characterFactory;

        public void Lock()
        {

        }

        public void Unlock()
        {

        }
    }
}