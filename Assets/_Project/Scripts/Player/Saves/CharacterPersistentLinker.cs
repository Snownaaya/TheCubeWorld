using Assets.Scripts.Datas.Character;
using Assets.Scripts.Player.Skins;
using Assets.Scripts.Service.GameMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace Assets.Scripts.Player.Saves
{
    public class CharacterPersistentLinker : IDisposable
    {
        private const string MoneyKey = nameof(MoneyKey); 
        private const string SelectedSkinKey = nameof(SelectedSkinKey);
        private const string OpenSkinsKey = nameof(OpenSkinsKey);

        private readonly ICharacterSaveRepository _repository;
        private readonly IPersistentCharacterData _data;

        private GameMessageBus _gameMessageBus;
        private CompositeDisposable _compositeDisposable = new();

        public CharacterPersistentLinker(
            ICharacterSaveRepository repository,
            IPersistentCharacterData data,
            GameMessageBus gameMessageBus)
        {
            _repository = repository;
            _data = data;
            _gameMessageBus = gameMessageBus;
        }

        public void Dispose() =>
            _compositeDisposable.Dispose();

        public void Link()
        {
            IEnumerable<CharacterSkins> savedSkins = _repository.Load(OpenSkinsKey, new List<CharacterSkins> { CharacterSkins.Bunny });

            _data.SelectedCharacterSkin = _repository.Load(SelectedSkinKey, CharacterSkins.Bunny);

            _data.Money.Value = _repository.Load(MoneyKey, 10000);

            _data.SetOpenSkins(savedSkins);

            _gameMessageBus.MessageBroker
                .Receive<IPersistentCharacterData>()
                .Subscribe(data =>
                {
                    _repository.Save(MoneyKey, data.Money.Value);
                    _repository.Save(SelectedSkinKey, data.SelectedCharacterSkin);
                    _repository.Save(OpenSkinsKey, data.OpenCharacterSkins.ToList());
                })
                .AddTo(_compositeDisposable);
        }
    }
}