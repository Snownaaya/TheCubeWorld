using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Other
{
    [RequireComponent(typeof(RawImage))]
    public class ImageScroller : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float _scrollSpeed;

        [SerializeField] private float _xDirection = -1;
        [SerializeField] private float _yDirection = -1;

        private RawImage _rawImage;

        private void Awake() =>
            _rawImage = GetComponent<RawImage>();

        private void Update()
        {
            _rawImage.uvRect = new Rect(_rawImage.uvRect.position + new Vector2(_xDirection
                   * _scrollSpeed,
                   _yDirection *
                   _scrollSpeed) *
                   Time.unscaledDeltaTime,
                   _rawImage.uvRect.size);
        }
    }
}