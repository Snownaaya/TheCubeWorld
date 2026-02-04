using Assets.Scripts.UI.FinishedUI;
using Cysharp.Threading.Tasks;
using System;
using System.Linq;
using System.Threading;
using UnityEngine;

public class SpinUseCase
{
    private RewardSlotView[] _slots;
    private float _durationOneWay = 1.0f;

    public SpinUseCase(RewardSlotView[] slots) =>
        _slots = slots;

    public event Action<float> OnPositionChanged; 
    public event Action<int> OnSlotChanged;

    public async UniTask StartSpin(CancellationToken token)
    {
        float minX = _slots.First().Anchor.position.x;
        float maxX = _slots.Last().Anchor.position.x;
        int slotsCount = _slots.Length - 1;

        float progress = 0f;
        int direction = 1;
        int lastReportedIndex = -1;

        while (token.IsCancellationRequested == false)
        {
            progress += (Time.deltaTime / _durationOneWay) * direction;

            if (progress >= 1f)
            {
                progress = 1f;
                direction = -1;
            }
            else if (progress <= 0f)
            {
                progress = 0f;
                direction = 1;
            }

            float currentX = Mathf.Lerp(minX, maxX, progress);
            OnPositionChanged?.Invoke(currentX);

            int currentIndex = Mathf.RoundToInt(progress * slotsCount);

            if (currentIndex != lastReportedIndex)
            {
                lastReportedIndex = currentIndex;
                OnSlotChanged?.Invoke(currentIndex);
            }

            await UniTask.NextFrame(token);
        }
    }
}
