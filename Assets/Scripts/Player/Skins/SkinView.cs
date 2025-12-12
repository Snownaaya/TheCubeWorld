using Assets.Scripts.Datas.Character;
using UnityEngine;

namespace Assets.Scripts.Player.Skins
{
    public class SkinView : MonoBehaviour
    {
        [SerializeField] private SkinConfig _skinConfig;

        public CharacterSkins SkinType => _skinConfig.CharacterSkins;
    }
}