using System;
using UnityEngine;

public class DirtButton : BridgeBuilder
{
    private event Action ButtonClicked;

    protected override void OnClickButton()
    {
        ButtonClicked?.Invoke();
        if (BuildingArea.TryGetComponent(out BuildingArea buildingArea))
            buildingArea.DeliveResource(Resource);
        
    }
}
