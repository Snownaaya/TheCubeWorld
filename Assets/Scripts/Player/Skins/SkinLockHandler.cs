using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.Core;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace Assets.Scripts.Player.Skins
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

            //foreach (CharacterSkins skin in Enum.GetValues(typeof(CharacterSkins)))
            //{
            //    _characterFactory.Get(skin);
            //}
        }

        public void Unlock()
        {
            IsLock = false;
        }
    }
}