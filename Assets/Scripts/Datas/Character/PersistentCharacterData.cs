using Assets.Scripts.Player.Saves;
using Assets.Scripts.Player.Skins;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UniRx;

namespace Assets.Scripts.Datas.Character
{
    public class PersistentCharacterData : IPersistentCharacterData
    {
        private const string SelectedSkinKey = nameof(SelectedSkinKey);
        private const string OpenSkinsKey = nameof(OpenSkinsKey);
        private const string MoneyKey = nameof(MoneyKey);

        private readonly ICharacterSaveRepository _save;

        private ReactiveProperty<int> _money;

        private CharacterSkins _characterSkins;
        private List<CharacterSkins> _openSkins;

        public PersistentCharacterData(ICharacterSaveRepository save)
        {
            _save = save;

            _money = new ReactiveProperty<int>(_save.Load(MoneyKey, 0));

            _money.Subscribe(value =>
            {
                _save.Save(MoneyKey, value);
            });

            _characterSkins = _save.Load(
                SelectedSkinKey,
                CharacterSkins.Bunny
            );

            _openSkins = _save.Load(
                OpenSkinsKey,
                new List<CharacterSkins>() { CharacterSkins.Bunny }
            );
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
                _save.Save(SelectedSkinKey, _characterSkins);
            }
        }

        public IEnumerable<CharacterSkins> OpenCharacterSkins => _openSkins;

        public void OpenCharacterSkin(CharacterSkins characterSkins)
        {
            if (_openSkins.Contains(characterSkins))
                return;

            _openSkins.Add(characterSkins);
            _save.Save(OpenSkinsKey, _openSkins);
        }
    }
}