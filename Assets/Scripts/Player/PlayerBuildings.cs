using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildings
{
    private List<Building> buildings;
    private Player player;

    private Dictionary<Vector3Int, Building> test;

    public PlayerBuildings(Player player)
    {
        buildings = new List<Building>();
        this.player = player;
        test = new Dictionary<Vector3Int, Building>();
    }

    // prida budovu do zoznamu
    public void Add(Building building, Vector3Int position)
    {
        if (building == null)
            throw new NoBuildingException();

        //buildings.Add(building);

        test[position] = building;
    }

    // vymaze budovu zo zoznamu
    /*public void Remove(Building building)
    {
        if (building == null)
            throw new NoBuildingException();
        if (!buildings.Contains(building))
            throw new WrongBuildingException();

        buildings.Remove(building);
        
    }*/

    public Building Remove(Vector3Int position)
    {
        if (!test.ContainsKey(position))
        {
            Debug.Log("No such building here.");
            return null;
        }
            

        Building building = this.GetBuilding(position);
        test.Remove(position);
        return building;
    }

    public void UpdateBuildings()
    {
        /*
        foreach (Building building in buildings)
        {
            building.DoStuff(player);
        }*/

        foreach (Building building in test.Values)
            building.DoStuff(this.player);
    }

    internal Building GetBuilding(Vector3Int position)
    {
        /*
        foreach (Building building in buildings)
        {
            if (building.position == position)
                return building;
        }

        return null;
        */

        if (!test.ContainsKey(position))
            return null;

        return test[position];
    }
}
