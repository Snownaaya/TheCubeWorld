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

        private void Awake() =>
            Initialize();

        [Inject]
        public void Construct(VisitorsHolder visitorsHolder, VisitorFactory visitorFactory)
        {
            _visitorFactory = visitorFactory;
            _visitorsHolder = visitorsHolder;
        }

        public void Initialize() =>
            _shop.Initialize(_visitorsHolder, _visitorFactory);

        private void OnDisable() =>
            _shop.Dispose();
    }
}