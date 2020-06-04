using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodGiving : Building
{
    private int reward;
    private int increaseReward;

    public WoodGiving(string name, int goldcost, int woodcost, int stonecost, int requiredxp, int increasexp, int xpreward, int woodReward, int increaseRewardAmount) : 
        base(name, goldcost, woodcost, stonecost, requiredxp, increasexp, xpreward)
    {
        this.reward = woodReward;
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
            this.reward += increaseReward;
        }

        player.AddWood(this.reward);
    }

    public override string GetDescription()
    {
        return string.Format("Gives {0} wood per turn.", this.reward);
    }

}
