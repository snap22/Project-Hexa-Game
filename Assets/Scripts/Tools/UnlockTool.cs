using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UnlockTool : ITool
{
    private TileModifier tm;
    private Tilemap lockedTileMap;
    private int numberOfNeigbours;

    List<Vector3Int> neighbours;

    public UnlockTool(Tilemap lockedTileMap)
    {
        tm = new TileModifier();
        this.lockedTileMap = lockedTileMap;
        this.numberOfNeigbours = 0;
    }

    public void Check(Vector3Int position, Tilemap tilemap)
    {
        numberOfNeigbours = 0;

        neighbours = tm.GetNeighbours(position, 2);
        
        foreach (Vector3Int neighbour in neighbours)
        {
            if (lockedTileMap.GetTile(neighbour) != null)
                numberOfNeigbours++;

            lockedTileMap.SetTile(neighbour, null);
        }
    }
        public void Draw(Vector3Int position, Tilemap tilemap, TileBase tile)
    {
        foreach (Vector3Int neighbour in neighbours)
            lockedTileMap.SetTile(neighbour, null);
    }

    public void Manage(Player player, Building building, Vector3Int position)
    {
        int price = 0;
        for (int i = 0; i < numberOfNeigbours; i++)
        {
            price += 5;
        }

        player.RemoveGold(price);
    }

}
