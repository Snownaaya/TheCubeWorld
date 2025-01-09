using Assets.Scripts.Items;
using System;
using UnityEngine;

public class DirtBridge : Bridge
{
    private int _dirtCount = 10;
    private float _scaleHeight = 0.5f;

    public override int Amount => _dirtCount;
    public override bool IsBuilding => true;
    public override float BuildProgress => throw new NotImplementedException();

    

    public override void Initialized(ResourceStorage resourceStorage, Vector3 position)
    {
        //_resourceStorage = resourceStorage;
        //_originalPosition = position;
    }
}
