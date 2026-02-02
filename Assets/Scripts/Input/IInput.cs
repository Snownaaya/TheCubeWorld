using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Input
{
    public interface IInput : IDisposable
    {
        public Vector2 Move { get; }
        event Action<Vector3> Moved;
        event Action Stopped;
    }
}