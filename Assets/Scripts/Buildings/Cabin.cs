using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cabin : Building
{
    private int goldReward;
    public Cabin(TileBase tile, TileBase picture) : base("Cabin", tile, picture, 500, 150, 50, 20, 20, 8)
    {
        this.goldReward = 20;
    }
    public override void DoStuff(Player player)
    {
        try
        {
            base.AddXp(1);
        }
        catch (LevelUpException)
        {
            this.goldReward = base.Level * 20;
        }

        player.AddGold(this.goldReward);

    }

    public override string GetDescription()
    {
        return "Cabin";
    }
}
