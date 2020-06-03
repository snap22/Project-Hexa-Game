using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StarterHouse : Building
{
    
    public StarterHouse(TileBase tile, TileBase picture) : base("House", tile, picture, 0, 0, 0, 5, 5, 0)
    {
        
    }
    public override void DoStuff(Player player)
    {
        try
        {
            base.AddXp(1);
        }
        catch (LevelUpException)
        {
            // do nothing
        }

        player.AddGold(2);
        player.AddWood(1);
        player.AddStone(1);

    }

    public override string GetDescription()
    {
        return "Starting house";
    }
}
