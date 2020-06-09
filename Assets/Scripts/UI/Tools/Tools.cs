using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public interface ITool
{
    void Draw(Vector3Int position, Tilemap tilemap, TileBase tile);

    void Manage(Player player, Building building, Vector3Int position);

    void Check(Vector3Int position, Tilemap tilemap);

    void ShowAnimation(ObjectSpawner spawner, Vector3 position);
    
}