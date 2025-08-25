using System;
using UnityEngine;

namespace Assets.Scripts.Input
{
    public interface IInput
    {
        public Vector2 Move { get; }
        event Action<Vector3> Moved;
        event Action Stopped;
    }
}