using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StarterHouse : Building
{
    private int goldReward;
    public StarterHouse(TileBase tile, TileBase picture) : base("House", tile, picture, 0, 0, 0, 5, 5, 0)
    {
        this.goldReward = 2;
    }
    public override void DoStuff(Player player)
    {
        try
        {
            base.AddXp(1);
        }
        catch (LevelUpException)
        {
            this.goldReward = base.Level * 2;
        }

        player.AddGold(this.goldReward);

    }

    public override string GetDescription()
    {
        return "Starting house";
    }
}
