using Assets.Scripts.Player.Saves;
using Assets.Scripts.Player.Skins;
using System;
using System.Collections.Generic;
using UniRx;

namespace Assets.Scripts.Datas.Character
{
    public class PersistentCharacterData : IPersistentCharacterData
    {
        private const string CharacterSkins = nameof(CharacterSkins);

        private readonly ICharacterSaveRepository _save;

        private ReactiveProperty<int> _money;

        private CharacterSkins _characterSkins;
        private List<CharacterSkins> _openSkins;

        public PersistentCharacterData(ICharacterSaveRepository characterSaveRepository)
        {
            _save = characterSaveRepository;

            _openSkins = new List<CharacterSkins>() { _characterSkins };
            _money = new ReactiveProperty<int>(1);

            _save.Load(CharacterSkins, _characterSkins);

            _characterSkins = Player.Skins.CharacterSkins.Bunny;
        }

        public ReactiveProperty<int> Money
        {
            get => _money;
            protected set
            {
                _money = value;
            }
        }

        public CharacterSkins SelectedCharacterSkin
        {
            get => _characterSkins;
            set
            {
                if (_openSkins.Contains(value) == false)
                    throw new ArgumentException(nameof(value));

                _characterSkins = value;
            }
        }

        public IEnumerable<CharacterSkins> OpenCharacterSkins => _openSkins;

        public void OpenCharacterSkin(CharacterSkins characterSkins)
        {
            if (_openSkins.Contains(characterSkins))
                return;

            _save.Save(CharacterSkins, characterSkins);
            _openSkins.Add(characterSkins);
        }
    }
}