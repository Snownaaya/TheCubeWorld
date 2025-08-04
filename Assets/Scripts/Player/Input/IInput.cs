using System;
using UnityEngine;

namespace Assets.Scripts.Player.Input
{
    public interface IInput
    {
        event Action<Vector3> Moved;
    }
}