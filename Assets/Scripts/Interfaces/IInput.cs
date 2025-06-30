using System;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IInput
    {
        event Action<Vector3> Moved;
    }
}