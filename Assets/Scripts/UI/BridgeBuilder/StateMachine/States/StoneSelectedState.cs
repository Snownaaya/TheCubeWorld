using Assets.Scripts.UI.BridgeBuilder;
using Assets.Scripts.Items;
using DG.Tweening;

public class StoneSelectedState : BaseBridgeState
{
    private ResourceTypes _stoneType = ResourceTypes.Stone;

    public StoneSelectedState(BuildButton buildButton) : base(buildButton) { }

    public override void Enter()
    {
        base.Enter();

        DeliverResourceToBridge(_stoneType);

        BuildButton.StoneButton.transform.DOKill();
        BuildButton.StoneButton.transform.DOScale(0.8f, 0);
    }

    public override void Exit()
    {
        base.Exit();

        BuildButton.StoneButton.transform.DOKill();
        BuildButton.StoneButton.transform.DOScale(1, 0.25f).From(0.8f).SetEase(Ease.OutBack);
    }
}