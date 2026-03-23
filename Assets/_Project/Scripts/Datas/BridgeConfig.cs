using System;
using Assets.Scripts.Bridge;
using Assets.Scripts.Bridge.Factory;
using UnityEngine;

[Serializable]
public class BridgeConfig
{
    [SerializeField] private Bridge _bridgePrefab;
    [SerializeField] private BridgeType _type;

    public Bridge BridgePrefab => _bridgePrefab;

    public BridgeType BridgeType => _type;
}