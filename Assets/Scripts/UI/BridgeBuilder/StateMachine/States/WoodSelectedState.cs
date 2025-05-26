using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Assets.Scripts.UI.BridgeBuilder;
using DG.Tweening;

public class WoodSelectedState : BaseBridgeState
{
    private ResourceType _woodType = ResourceType.Wood;

    public WoodSelectedState(ISwitcher switcher, BuildButton buildButton) : base(switcher, buildButton) { }

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

        BuildButton.StoneButton.transform.DOKill();
        BuildButton.StoneButton.transform.DOScale(1, 0.25f).From(0.8f).SetEase(Ease.OutBack);
    }
}