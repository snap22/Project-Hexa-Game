using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildTool : ITool
{
    private Tilemap lockedMap;

    private Building currentBuilding;

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
        this.currentBuilding = building;
    }

    public void ShowAnimation(ObjectSpawner spawner, Vector3 position)
    {
        int gold = this.currentBuilding.goldCost;
        int wood = this.currentBuilding.woodCost;
        int stone = this.currentBuilding.stoneCost;
        int xp = this.currentBuilding.xpReward;

        string final = string.Format("  - {0} gold \n   - {1} wood \n   - {2} stone \n  + {3} xp", gold, wood, stone, xp);
        spawner.SetInfoText(position,final);
    }
}
