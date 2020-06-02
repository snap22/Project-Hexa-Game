using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildings
{
    private List<Building> buildings;
    private Player player;

    public PlayerBuildings(Player player)
    {
        buildings = new List<Building>();
        this.player = player;
    }

    // prida budovu do zoznamu
    public void Add(Building building)
    {
        if (building == null)
            throw new NoBuildingException();

        buildings.Add(building);
    }

    // vymaze budovu zo zoznamu
    public void Remove(Building building)
    {
        if (building == null)
            throw new NoBuildingException();
        if (!buildings.Contains(building))
            throw new WrongBuildingException();

        buildings.Remove(building);
    }

    public void UpdateBuildings()
    {
        foreach (Building building in buildings)
        {
            building.DoStuff(player);
        }
    }

}
