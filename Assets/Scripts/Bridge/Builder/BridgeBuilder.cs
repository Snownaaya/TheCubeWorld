using UnityEngine;
using UnityEngine.UI;

public abstract class BridgeBuilder : MonoBehaviour
{
    private const string Buttons = nameof(Buttons);

    [SerializeField] private Bridge _bridge;
    [SerializeField] private BuildingArea _area;
    [SerializeField] private Button _button;
    [SerializeField] private Resource _resource;

    public BuildingArea BuildingArea => _area;
    public Resource Resource => _resource;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClickButton);
        _area.ResourceDelivered += _bridge.Build;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClickButton);
        _area.ResourceDelivered -= _bridge.Build;
    }

    protected abstract void OnClickButton();
}