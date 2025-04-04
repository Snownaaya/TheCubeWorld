using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private BridgePart[] _bridgeParts;
    [SerializeField] private BuildingArea _buildingArea;
    
    [SerializeField] private Material _blueprintMaterial;
    [SerializeField] private Material _invisibleMaterial;
    
    private int _buildedPartsCount = 0;
    
    private void OnValidate()
    {
        _bridgeParts = GetComponentsInChildren<BridgePart>();
        _buildingArea = GetComponentInChildren<BuildingArea>();

        _bridgeParts[0].SetMaterial(_blueprintMaterial);
        
        for (int i = 1; i < _bridgeParts.Length; i++)
        {
            _bridgeParts[i].SetMaterial(_invisibleMaterial);
        }
    }

    public void Build(Resource resource)
    {
        _bridgeParts[_buildedPartsCount].TryBuild(resource.Material);
        
        if (_bridgeParts[_buildedPartsCount].IsBuilded)
        {
            _buildedPartsCount++;
            _buildingArea.MoveBarrier();

            if (_bridgeParts[_buildedPartsCount].IsBuilded)
            {
                Debug.LogError("При попытке достроить блок в деталь, " +
                               "код подумал что после полного создания одной детали следующая уже построена, " +
                               "такой хуйни быть не должно, " +
                               "обратитесь к ебаклаку по имени Николай для его экстренного набутылирования");
            }
        }
    }
}