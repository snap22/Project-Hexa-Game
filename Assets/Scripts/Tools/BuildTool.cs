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

    public void Check(Vector3Int position, Tilemap tilemap)
    {
        if (lockedMap.GetTile(position) != null)
        {
            throw new LockedTileException();
        }

        if (tilemap.GetTile(position) != null)
        {
            throw new OccupiedTileException();
        }
    }

    public void Draw(Vector3Int position, Tilemap tilemap, TileBase tile)
    {
        tilemap.SetTile(position, tile);
    }


    public void Manage(Player player, Building building, Vector3Int position)
    {
        player.AddBuilding(building, position);
    }
}
