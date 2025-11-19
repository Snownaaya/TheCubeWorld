using Assets.Scripts.Datas;
using Assets.Scripts.Visitor.Visitors;

namespace Assets.Scripts.UI.Shop
{
    public class ShopVisitors
    {
        public ShopVisitors(CharacterData characterData)
        {
            ContentUnlock = new ContentUnlock(characterData);
            SkinSelector = new SkinSelector(characterData);
            SelectionChecker = new SelectionChecker(characterData);
            UnlockChecker = new UnlockChecker(characterData);
        }

        public ContentUnlock ContentUnlock { get; private set; }
        public SkinSelector SkinSelector { get; private set; }
        public SelectionChecker SelectionChecker { get; private set; }
        public UnlockChecker UnlockChecker { get; private set; }
    }
}