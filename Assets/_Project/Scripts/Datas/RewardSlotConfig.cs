namespace Assets.Project.Scripts.Datas
{
    using Assets.Scripts.UI.FinishedUI;
    using UnityEngine;

    [CreateAssetMenu(fileName = "RewardSlot", menuName = "RewardSlot/ScriptableObject")]
    public class RewardSlotConfig : ScriptableObject
    {
        [field: SerializeField] public RewardSlotView[] Slots;
    }
}