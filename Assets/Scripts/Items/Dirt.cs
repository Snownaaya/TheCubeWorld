using UnityEngine;

public class Dirt : Resource
{
    private int _dirtCount = 5;

    public override int Amount => _dirtCount;
}