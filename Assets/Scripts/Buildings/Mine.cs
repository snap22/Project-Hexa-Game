using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Mine : Building
{
    private int stoneReward;
    public Mine(TileBase tile, TileBase picture) : base("Mine", tile, picture, 40, 20, 20, 10, 10, 2)
    {
        this.stoneReward = 2;
    }
    public override void DoStuff(Player player)
    {
        try
        {
            base.AddXp(1);
        }
        catch (LevelUpException)
        {
            this.stoneReward = base.Level * 5;
        }

        player.AddStone(this.stoneReward);

    }

    public override string GetDescription()
    {
        return "Mine";
    }
}
