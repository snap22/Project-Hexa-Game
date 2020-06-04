using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGiving : Building
{
    private int goldReward;
    private int increaseReward;

    public GoldGiving(string name, int goldcost, int woodcost, int stonecost, int requiredxp, int increasexp, int xpreward, int goldReward, int increaseRewardAmount) :
        base(name, goldcost, woodcost, stonecost, requiredxp, increasexp, xpreward)
    {
        this.goldReward = goldReward;
        this.increaseReward = increaseRewardAmount;
    }
    public override void DoStuff(Player player)
    {
        try
        {
            base.AddXp(1);
        }
        catch (LevelUpException)
        {
            this.goldReward += increaseReward;
        }

        player.AddGold(this.goldReward);
    }

    public override string GetDescription()
    {
        return string.Format("Gives {0} gold per turn.", this.goldReward);
    }
}
    
