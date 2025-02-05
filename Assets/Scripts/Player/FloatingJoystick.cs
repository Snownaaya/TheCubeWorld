using System;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class FloatingJoystick : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private RectTransform _knob;


    public RectTransform RectTransform
    {
        get
        {
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();
            return _rectTransform;
        }
    }

    public RectTransform Knob => _knob;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
}
