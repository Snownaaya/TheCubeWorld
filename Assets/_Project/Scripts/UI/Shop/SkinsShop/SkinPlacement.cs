namespace Assets.Project.Scripts.UI.Shop.SkinsShop
{
    using Assets.Scripts.Player.Skins;
    using Assets.Scripts.UI.Shop.SO;
    using UnityEngine;

    public class SkinPlacement : MonoBehaviour
    {
        private SkinView[] _skinViews;

        private void Awake() =>
            _skinViews = GetComponentsInChildren<SkinView>(true);

        public void SkinsShow(
            CharacterSkinsItem characterSkinsItem)
        {
            foreach (SkinView skin in _skinViews)
            {
                skin.gameObject.SetActive(characterSkinsItem.CharacterSkins == skin.SkinType);
                skin.gameObject.layer = LayerMask.NameToLayer("SkinRender");
            }
        }
    }
}