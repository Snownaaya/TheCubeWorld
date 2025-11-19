using Assets.Scripts.Datas;
using Assets.Scripts.UI.Shop;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Domain
{
    public class ShopMediator : MonoBehaviour
    {
        [SerializeField] private Shop _shop;

        private CharacterData _characterData;

        private void Awake()
        {
            Initialize();
        }

        [Inject]
        public void Construct(CharacterData characterData) =>
            _characterData = characterData;

        public void Initialize()
        {
            ShopVisitors shopVisitors = new ShopVisitors(_characterData);
            
            _shop.Initialize(shopVisitors);
        }
    }
}
