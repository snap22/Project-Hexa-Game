using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Building
{
    public TileBase tile;
    public TileBase picture;
    public int goldCost { get; }
    public int woodCost { get; }
    public int stoneCost { get; }

    public Building(int goldCost, int woodCost, int stoneCost)
    {
        this.goldCost = goldCost;
        this.woodCost = woodCost;
        this.stoneCost = stoneCost;
    }

    public abstract void DoStuff(Player player);


}
