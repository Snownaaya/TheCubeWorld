using UnityEngine;

[CreateAssetMenu(fileName = "BridgeData", menuName = "ScriptableObject/Bridge", order = 1)]
public class BridgeData : ScriptableObject
{
    [SerializeField] private Resource _resorceRequirements;
    [SerializeField] private Bridge _bridge;

    public Resource Resource => _resorceRequirements;
    public Bridge Bridge => _bridge;
}