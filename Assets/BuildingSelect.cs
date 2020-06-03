using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSelect : MonoBehaviour
{
    public static BuildingSelect Instance;

    void Awake()
    {
        Instance = this;
    }

    [System.Serializable]
    public class BuildingSelection
    {
        public BuildingType type;
        public TileBase tile;
        public TileBase picture;
    }

    [SerializeField]
    public BuildingSelection[] buildings;

    
    
    public TileBase GetBuildingTile(int index)
    {
        if (index < 0 || index >= buildings.Length)
            return null;

        return buildings[index].tile;
    }
    
    public TileBase GetBuildingTile(BuildingType type)
    {
        return GetBuildingTile((int)type);
    }


    public Building GetBuilding(BuildingType type)
    {
        switch (type)
        {
            case BuildingType.Lumber:
                return new Lumber();
            case BuildingType.Cutter:
                return new Cutter();
            case BuildingType.Mine:
                return new Mine();
            case BuildingType.Blacksmith:
                return new BlackSmith();
            case BuildingType.Cabin:
                return new Cabin();
            case BuildingType.Castle:
                return new Castle();
            case BuildingType.StartingHouse:
                return new StarterHouse();
        }
        return null;
    }

    public Building GetBuilding(int index)
    {
        return GetBuilding((BuildingType)index);
    }


}
