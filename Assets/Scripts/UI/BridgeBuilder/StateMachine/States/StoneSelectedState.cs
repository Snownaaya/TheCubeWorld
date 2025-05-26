using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Assets.Scripts.UI.BridgeBuilder;
using DG.Tweening;

public class StoneSelectedState : BaseBridgeState
{
    private ResourceType _stoneType = ResourceType.Stone;

    public StoneSelectedState(ISwitcher switcher, BuildButton buildButton) : base(switcher, buildButton) { }

    public override void Enter()
    {
        base.Enter();

        BuildButton.StoneButton.transform.DOKill();
        BuildButton.StoneButton.transform.DOScale(0.8f, 0);

        DeliverResourceToBridge(_stoneType);
    }

    public override void Exit()
    {
        base.Exit();

        BuildButton.StoneButton.transform.DOKill();
        BuildButton.StoneButton.transform.DOScale(1, 0.25f).From(0.8f).SetEase(Ease.OutBack);
    }
}