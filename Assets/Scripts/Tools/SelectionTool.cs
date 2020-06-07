using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SelectionTool : ITool
{
    public void Check(Vector3Int position, Tilemap tilemap)
    {
        
    }

    public void Draw(Vector3Int position, Tilemap tilemap, TileBase tile)
    {
        Debug.Log(tilemap.GetTile(position));
    }

    public void Manage(Player player, Building building, Vector3Int position)
    {
        // do nothing
        // SHOW BUILDING
        Debug.Log(player.GetBuilding(position).ToString());
    }

}
