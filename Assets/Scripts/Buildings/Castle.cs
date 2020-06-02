using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Castle : Building
{
    private int goldReward;
    private int woodReward;
    private int stoneReward;
    public Castle(TileBase tile, TileBase picture) : base("Castle", tile, picture, 5000, 500, 1000, 20, 20, 10)
    {
        this.goldReward = 50;
        this.stoneReward = 5;
        this.woodReward = 5;
    }
    public override void DoStuff(Player player)
    {
        try
        {
            base.AddXp(1);
        }
        catch (LevelUpException)
        {
            this.goldReward = base.Level * 50;
            if (base.Level >= 5)        //ak je budova level 5 tak da 500 goldov namiesto 250 
                this.goldReward = 500;

            this.stoneReward = base.Level * 5;
            this.woodReward = base.Level * 5;
        }

        player.AddGold(this.goldReward);
        player.AddStone(this.stoneReward);
        player.AddWood(this.woodReward);

    }

    public override string GetDescription()
    {
        return "Magnificient castle";
    }
}
