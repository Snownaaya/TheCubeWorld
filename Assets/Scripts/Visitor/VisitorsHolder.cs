using Assets.Scripts.Datas;
using Assets.Scripts.Visitor.Visitors;

namespace Assets.Scripts.Visitor
{
    public class VisitorsHolder
    {
        public VisitorsHolder(CharacterData characterData)
        {
            ContentUnlock = new ContentUnlock(characterData);
            SkinSelector = new Purchase(characterData);
            SelectionChecker = new PurchaseChecker(characterData);
            UnlockChecker = new UnlockChecker(characterData);
        }

        public ContentUnlock ContentUnlock { get; private set; }
        public Purchase SkinSelector { get; private set; }
        public PurchaseChecker SelectionChecker { get; private set; }
        public UnlockChecker UnlockChecker { get; private set; }
    }
}