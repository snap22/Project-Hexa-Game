using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildTool : ITool
{
    private Tilemap lockedMap;

    public BuildTool(Tilemap lockedMap)
    {
        this.lockedMap = lockedMap;
    }
    public void Draw(Vector3Int position, Tilemap tilemap, TileBase tile)
    {
        if (lockedMap.GetTile(position) != null)
        {
            Debug.Log("Tile is locked");
            return;
        }
        if (tilemap.GetTile(position) == null)
            tilemap.SetTile(position, tile);
        else
            Debug.Log("This tile is not empty");
    }

    public void Manage(Player player, Building building)
    {
        player.AddBuilding(building);
    }
}
