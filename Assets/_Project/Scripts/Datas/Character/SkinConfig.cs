using Assets.Scripts.Player.Skins;
using UnityEngine;

namespace Assets.Scripts.Datas.Character
{
    [CreateAssetMenu(fileName = "CharacterSkins", menuName = "CharacterSkin/ScriptableObject")]
    public class SkinConfig : ScriptableObject
    {
        [field: SerializeField] public CharacterSkins CharacterSkins { get; private set; }
    }
}