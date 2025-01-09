using UnityEngine;
using Assets.Scripts.Interfaces;

public class Stone : Resource
{
    private int _stoneCount = 20;

    public override int Amount => _stoneCount;
}