using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class Blueprint
{
    public string name;

    public TileBase tile;
    public Sprite picture;

    public int goldCost;
    public int woodCost;
    public int stoneCost;

    public Category type;
    public Efficiency efficiency;
    
}
