using Assets.Scripts.Datas.Character;
using Assets.Scripts.Visitor.Visitors;

namespace Assets.Scripts.Visitor
{
    public class VisitorsHolder
    {
        public VisitorsHolder(IPersistentCharacterData persistentCharacterData, ITransientCharacterData transientCharacterData)
        {
            ContentUnlock = new ContentUnlock(persistentCharacterData, transientCharacterData);
            Purchase = new Purchase(persistentCharacterData, transientCharacterData);
            PurchaseChecker = new PurchaseChecker(persistentCharacterData, transientCharacterData);
            UnlockChecker = new UnlockChecker(persistentCharacterData, transientCharacterData);
        }

        public ContentUnlock ContentUnlock { get; private set; }
        public Purchase Purchase { get; private set; }
        public PurchaseChecker PurchaseChecker { get; private set; }
        public UnlockChecker UnlockChecker { get; private set; }
    }
}