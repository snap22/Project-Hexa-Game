using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RemoveTool : ITool
{
    public void Check(Vector3Int position, Tilemap tilemap)
    {
        if (tilemap.GetTile(position) == null)
            throw new EmptyTileException();
    }

    public void Draw(Vector3Int position, Tilemap tilemap, TileBase tile)
    {
        tilemap.SetTile(position, null);
    }

    public void Manage(Player player, Building building, Vector3Int position)
    {
        player.RemoveBuilding(position);
    }
}
