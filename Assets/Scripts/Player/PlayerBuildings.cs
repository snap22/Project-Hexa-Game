using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildings
{
    private Player player;

    private Dictionary<Vector3Int, Building> buildings;


    public int totalGoldPerTurn { get; private set; }
    public int totalWoodPerTurn { get; private set; }
    public int totalStonePerTurn { get; private set; }
    
    public PlayerBuildings(Player player)
    {
        this.player = player;
        buildings = new Dictionary<Vector3Int, Building>();

        this.totalGoldPerTurn = 0;
        this.totalStonePerTurn = 0;
        this.totalWoodPerTurn = 0;
    }

    // prida budovu do zoznamu
    public void Add(Building building, Vector3Int position)
    {
        if (building == null)
            throw new NoBuildingException();

        buildings[position] = building;
        
    }

    // vymaze budovu zo zoznamu podla pozicie a vrati ju
    public Building Remove(Vector3Int position)
    {
        if (!buildings.ContainsKey(position))
        {
            Debug.Log("No such building here.");
            return null;
        }
            

        Building building = this.GetBuilding(position);

        if (building.name == "Starting House")
            throw new NotRemovableBuildingException();

        buildings.Remove(position);
        return building;
    }

    public void UpdateBuildings()
    {
        foreach (Building building in buildings.Values)
            building.DoStuff(this.player);
    }

    public Building GetBuilding(Vector3Int position)
    {
        if (!buildings.ContainsKey(position))
            return null;

        return buildings[position];
    }


    public void Test()
    {
        foreach (Building building in buildings.Values)
            Debug.Log(building);
        Debug.Log("Number of buildings: " + buildings.Count);
    }
    
    public int Count
    {
        get { return this.buildings.Count; }
    }
}
