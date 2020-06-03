using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RemoveTool : ITool
{
    public void Draw(Vector3Int position, Tilemap tilemap, TileBase tile)
    {
        TileBase selectedTile = tilemap.GetTile(position);
        if (selectedTile == null)
            return;
        tilemap.SetTile(position, null);
    }

    public void Manage(Player player, Building building)
    {
        player.RemoveBuilding(building);
    }
}
