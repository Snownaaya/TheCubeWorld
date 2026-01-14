using Assets.Scripts.UI.FinishedUI;
using UnityEngine;
using DG.Tweening;
using System.Linq;

namespace Assets.Scripts.VictoryReward
{
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