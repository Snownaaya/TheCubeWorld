using Assets.Scripts.UI.BridgeBuilder;
using Assets.Scripts.Items;
using DG.Tweening;

public class DirtSelectedState : BaseBridgeState
{
    private ResourceTypes _dirtType = ResourceTypes.Dirt;

    public DirtSelectedState(BuildButton buildButton) : base(buildButton) { }

    public override void Enter()
    {
        base.Enter();

        DeliverResourceToBridge(_dirtType);
            
        BuildButton.DirtButton.transform.DOKill();
        BuildButton.DirtButton.transform.DOScale(0.8f, 0);
    }

    public override void Exit()
    {
        base.Exit();

        BuildButton.DirtButton.transform.DOKill();
        BuildButton.DirtButton.transform.DOScale(1, 0.25f).From(0.8f).SetEase(Ease.OutBack);
    }
}