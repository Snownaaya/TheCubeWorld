using UnityEngine;
using Assets.Scripts.Interfaces;

public class Wood : Resource
{
    private int _woodCount = 10;

    public override int Amount => _woodCount;
}