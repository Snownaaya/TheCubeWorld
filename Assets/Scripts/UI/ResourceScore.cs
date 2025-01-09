using Assets.Scripts.Player;
using UnityEngine;

public class ResourceScore : MonoBehaviour
{
    private PlayerInventory _playerInventory;

    private void Awake()
    {
        _playerInventory = new PlayerInventory();
    }
}