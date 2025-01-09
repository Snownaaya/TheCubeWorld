using Assets.Scripts.Items;
using System;
using UnityEngine;

public class ConcreteBridge : Bridge
{
    public override int Amount => throw new NotImplementedException();

    public override bool IsBuilding => throw new NotImplementedException();

    public override float BuildProgress => throw new NotImplementedException();

    public override Material Material => _material;

    public override void Build(BridgeData bridgeData, Vector3 position, int resourceCount)
    {
        
    }

    public override void Initialized(ResourceStorage resourceStorage, Vector3 position)
    {
        throw new NotImplementedException();
    }
}