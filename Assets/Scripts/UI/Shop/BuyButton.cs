using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private Button _buyButton;

    [SerializeField, Range(0, 1)] private float _lockAnimationDuration = 0.4f;
    [SerializeField, Range(0.5f, 5)] private float _lockAnimationStrength = 2f;

    public event Action Clicked;

    public void Show() =>
        _buyButton.gameObject.SetActive(true); 
    public void Hide() =>
        _buyButton.gameObject.SetActive(false);

    private void OnEnable() =>
        _buyButton.onClick.AddListener(OnClick);

    private void OnDisable() =>
        _buyButton.onClick.RemoveListener(OnClick);

    private void OnClick()
    {
        Clicked?.Invoke();
        _buyButton.transform.DOShakePosition(_lockAnimationDuration, _lockAnimationStrength);
    }
}