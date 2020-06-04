using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingFactory : MonoBehaviour
{
# region Singleton
    public static BuildingFactory Instance;
    void Awake()
    {
        Instance = this;
    }
    #endregion 


    [SerializeField]
    public Blueprint[] buildings;

    private Dictionary<string, Blueprint> dictionary;

    void Start()
    {
        dictionary = new Dictionary<string, Blueprint>();

        for (int i = 0; i < buildings.Length; i++)
        {
            dictionary.Add(buildings[i].name, buildings[i]);
        }
    }

    // vrati budovu na zaklade zadaneho mena 
    public Building GetBuilding(string buildingName)
    {
        if (!dictionary.ContainsKey(buildingName))
            return null;

        Blueprint current =  dictionary[buildingName];

        return GenerateBuilding(current);
    }

    public Sprite GetPicture(string buildingName)
    {
        if (!dictionary.ContainsKey(buildingName))
            return null;

        return dictionary[buildingName].picture;
    }

    public TileBase GetTile(string buildingName)
    {
        if (!dictionary.ContainsKey(buildingName))
            return null;

        return dictionary[buildingName].tile;
    }

    

    // vrati budovu na zaklade blueprintu, podla efficiency nastavi urcite hodnoty a podla typu vrati konkretnu budovu
    private Building GenerateBuilding(Blueprint blueprint)
    {
        string buildingName = blueprint.name;
        int goldCost = blueprint.goldCost;
        int woodCost = blueprint.woodCost;
        int stoneCost = blueprint.stoneCost;
        int requiredXp = 0;
        int increaseXp = 0;
        int xpReward = 0;
        int materialReward = 0;
        int materialRewardIncrease = 0;

        switch (blueprint.efficiency)
        {
            case Efficiency.Basic:
                requiredXp = 5;
                increaseXp = 5;
                xpReward = 1;
                materialReward = 1;
                materialRewardIncrease = 1;
                break;
            case Efficiency.Small:
                requiredXp = 10;
                increaseXp = 5;
                xpReward = 2;
                materialReward = 2;
                materialRewardIncrease = 1;
                break;
            case Efficiency.Medium:
                requiredXp = 25;
                increaseXp = 10;
                xpReward = 5;
                materialReward = 3;
                materialRewardIncrease = 2;
                break;
            case Efficiency.Large:
                requiredXp = 50;
                increaseXp = 10;
                xpReward = 10;
                materialReward = 4;
                materialRewardIncrease = 2;
                break;
            case Efficiency.Ultra:
                requiredXp = 100;
                increaseXp = 20;
                xpReward = 20;
                materialReward = 5;
                materialRewardIncrease = 3;
                break;
        }


        switch (blueprint.type)
        {
            case Category.Wood:
                return new WoodGiving(name, goldCost, woodCost, stoneCost, requiredXp, increaseXp, xpReward, materialReward, materialRewardIncrease);
            case Category.Stone:
                return new StoneGiving(name, goldCost, woodCost, stoneCost, requiredXp, increaseXp, xpReward, materialReward, materialRewardIncrease);
            case Category.Gold:
                return new GoldGiving(name, goldCost, woodCost, stoneCost, requiredXp, increaseXp, xpReward, materialReward, materialRewardIncrease);
            case Category.Multi:
                return new MultiGiving(name, goldCost, woodCost, stoneCost, requiredXp, increaseXp, xpReward, materialReward, materialReward, materialReward, materialRewardIncrease);
            case Category.Decoration:
                return new Decoration(name, goldCost);

        }

        return null;
    }
}
