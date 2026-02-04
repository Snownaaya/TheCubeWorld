namespace Assets.Scripts.Visitor
{
    public interface IShopElement
    {
        public void Accept(IShopVisitor shopVisitor);
    }
}