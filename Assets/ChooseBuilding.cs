using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChooseBuilding : MonoBehaviour
{
    [SerializeField]
    BuildingType selectedType;
    TileBase selectedTile;

    
    public void SelectBuilding(int index)
    {
        this.selectedType = (BuildingType)index;
        this.selectedTile = BuildingSelect.Instance.GetBuildingTile(selectedType);
    }


}
