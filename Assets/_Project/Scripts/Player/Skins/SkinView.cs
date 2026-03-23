namespace Assets.Scripts.Player.Skins
{
    using Assets.Scripts.Datas.Character;
    using UnityEngine;

    public class SkinView : MonoBehaviour
    {
        [SerializeField] private SkinConfig _skinConfig;

        public CharacterSkins SkinType => _skinConfig.CharacterSkins;
    }
}