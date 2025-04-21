using Assets.Scripts.Bridge;
using UnityEngine;
using System;

[Serializable]
public class BridgeConfig
{
    [SerializeField] private Bridge _bridgePrefab;
    [SerializeField] private int _count;

    public Bridge BridgePrefab => _bridgePrefab;
    public int Count => _count;
}