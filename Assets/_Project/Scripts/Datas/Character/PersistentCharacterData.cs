using Assets.Scripts.Datas.Character;
using Assets.Scripts.Player.Skins;
using Assets.Scripts.Service.GameMessage;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using Unity.VisualScripting;

public class PersistentCharacterData : IInitializable, IPersistentCharacterData
{
    private readonly GameMessageBus _gameMessageBus;
    private readonly CompositeDisposable _compositeDisposable = new();

    private readonly ReactiveProperty<int> _money = new(0);
    private List<CharacterSkins> _openSkins = new();
    private CharacterSkins _characterSkins;

    public PersistentCharacterData(GameMessageBus gameMessageBus)
    {
        _gameMessageBus = gameMessageBus;

        _characterSkins = CharacterSkins.Bunny;

        if (_openSkins.Contains(CharacterSkins.Bunny) == false)
            _openSkins.Add(CharacterSkins.Bunny);
    }

    public ReactiveProperty<int> Money => _money;

    public CharacterSkins SelectedCharacterSkin
    {
        get => _characterSkins;
        set
        {
            if (_characterSkins == value)
                return;

            _characterSkins = value;

            NotifyChanged();
        }
    }

    public IReadOnlyList<CharacterSkins> OpenCharacterSkins => _openSkins;

    public void OpenCharacterSkin(CharacterSkins skin)
    {
        if (_openSkins.Contains(skin)) return;
        _openSkins.Add(skin);

        NotifyChanged();
    }

    public void SetOpenSkins(IEnumerable<CharacterSkins> skins)
    {
        _openSkins = skins.ToList();
    }

    private void NotifyChanged() => _gameMessageBus.MessageBroker.Publish<IPersistentCharacterData>(this);

    public void Dispose() => _compositeDisposable.Dispose();

    public void Initialize()
    {
        _money
            .Skip(1)
            .Subscribe(_ => NotifyChanged())
            .AddTo(_compositeDisposable);
    }
}