using Assets.Scripts.UI.BridgeBuilder;
using Assets.Scripts.Items;
using DG.Tweening;

public class WoodSelectedState : BaseBridgeState
{
    private ResourceTypes _woodType = ResourceTypes.Wood;

    public WoodSelectedState(BuildButton buildButton) : base(buildButton) { }

    public override void Enter()
    {
        base.Enter();

        DeliverResourceToBridge(_woodType);

        BuildButton.WoodButton.transform.DOKill();
        BuildButton.WoodButton.transform.DOScale(0.8f, 0);
    }

    public override void Exit()
    {
        base.Exit();

        BuildButton.WoodButton.transform.DOKill();
        BuildButton.WoodButton.transform.DOScale(1, 0.25f).From(0.8f).SetEase(Ease.OutBack);
    }
}