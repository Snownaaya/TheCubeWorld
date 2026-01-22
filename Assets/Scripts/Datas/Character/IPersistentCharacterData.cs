using Assets.Scripts.Player.Skins;
using System.Collections.Generic;
using UniRx;
using UnityEngine.Scripting;

namespace Assets.Scripts.Datas.Character
{
    [Preserve]
    public interface IPersistentCharacterData
    {
        public ReactiveProperty<int> Money { get; }
        public CharacterSkins SelectedCharacterSkin { get; set; }
        public IEnumerable<CharacterSkins> OpenCharacterSkins { get; }
        public void OpenCharacterSkin(CharacterSkins characterSkins);
    }
}