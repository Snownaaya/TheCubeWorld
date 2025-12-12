using Assets.Scripts.Datas.Character;
using Assets.Scripts.Visitor;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.UI.Shop
{
    public class ShopBootstrap : MonoBehaviour
    {
        [SerializeField] private Shop _shop;

        private VisitorsHolder _visitorsHolder;
        private VisitorFactory _visitorFactory;

        private IPersistentCharacterData _persistentCharacterData;
        private ITransientCharacterData _transientCharacterData;

        [Inject]
        public void Construct(IPersistentCharacterData persistentCharacterData,
            ITransientCharacterData transientCharacterData)
        {
            _persistentCharacterData = persistentCharacterData;
            _transientCharacterData = transientCharacterData;

            Initialize();
        }

        public void Initialize()
        {
            _visitorFactory = new VisitorFactory();
            _visitorsHolder = new VisitorsHolder(_persistentCharacterData, _transientCharacterData);
            _shop.Initialize(_visitorsHolder, _visitorFactory);
        }

        private void OnDisable() =>
            _shop.Dispose();
    }
}