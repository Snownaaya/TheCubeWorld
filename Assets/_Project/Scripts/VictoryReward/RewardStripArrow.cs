namespace Assets.Scripts.VictoryReward
{
    using Assets.Scripts.UI.FinishedUI;
    using UnityEngine;

    public class RewardStripArrow : MonoBehaviour
    {
        [SerializeField] private RewardSlotView[] _slots;

        public void MoveArrow(float xPosition)
        {
            Vector3 position = transform.position;
            position.x = xPosition;
            transform.position = position;
        }
    }
}