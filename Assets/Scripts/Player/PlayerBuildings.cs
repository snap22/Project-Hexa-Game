using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildings
{
    private Player player;

    private Dictionary<Vector3Int, Building> test;


    public int totalGoldPerTurn { get; private set; }
    public int totalWoodPerTurn { get; private set; }
    public int totalStonePerTurn { get; private set; }
    
    public PlayerBuildings(Player player)
    {
        this.player = player;
        test = new Dictionary<Vector3Int, Building>();

        this.totalGoldPerTurn = 0;
        this.totalStonePerTurn = 0;
        this.totalWoodPerTurn = 0;
    }

    // prida budovu do zoznamu
    public void Add(Building building, Vector3Int position)
    {
        if (building == null)
            throw new NoBuildingException();

        test[position] = building;
        
    }

    // vymaze budovu zo zoznamu podla pozicie a vrati ju
    public Building Remove(Vector3Int position)
    {
        if (!test.ContainsKey(position))
        {
            Debug.Log("No such building here.");
            return null;
        }
            

        Building building = this.GetBuilding(position);

        if (building.name == "Starting House")
            throw new NotRemovableBuildingException();

        test.Remove(position);
        return building;
    }

    public void UpdateBuildings()
    {


        foreach (Building building in test.Values)
            building.DoStuff(this.player);
    }

    public Building GetBuilding(Vector3Int position)
    {
        if (!test.ContainsKey(position))
            return null;

        return test[position];
    }

    
}
