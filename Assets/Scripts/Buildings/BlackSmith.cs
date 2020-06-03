using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlackSmith : Building
{
    private int goldReward;
    public BlackSmith() : base("Blacksmith", 200, 100, 100, 20, 20, 4)
    {
        this.goldReward = 5;
    }
    public override void DoStuff(Player player)
    {
        try
        {
            base.AddXp(1);
        }
        catch (LevelUpException)
        {
            this.goldReward = base.Level * 5;
        }

        player.AddGold(this.goldReward);

    }

    public override string GetDescription()
    {
        return "Blacksmith";
    }
}
