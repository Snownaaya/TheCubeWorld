namespace Assets.Project.Scripts.UI.SelectButtons
{
    public class BridgeChoicePanel : BridgeChoiceStrategy
    {
        public void Destroyed() =>
            Destroy(gameObject);
    }
}