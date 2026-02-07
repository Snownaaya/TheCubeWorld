using Assets.Scripts.Player.Skins;
using System;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;

namespace Assets.Scripts.Datas.Character
{
    public interface IPersistentCharacterData : IInitializable, IDisposable
    {
        public ReactiveProperty<int> Money { get; }
        public CharacterSkins SelectedCharacterSkin { get; set; }
        public IReadOnlyList<CharacterSkins> OpenCharacterSkins { get; }
        public void OpenCharacterSkin(CharacterSkins characterSkins);
        public void SetOpenSkins(IEnumerable<CharacterSkins> skins);
    }
}
