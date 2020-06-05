using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiGiving : Building
{
    private int stoneReward;
    private int woodReward;
    private int goldReward;
    private int increaseReward;

    public MultiGiving(string name, int goldcost, int woodcost, int stonecost, int requiredxp, int increasexp, int xpreward, int stoneReward, int woodReward, int goldReward, int increaseRewardAmount) :
        base(name, goldcost, woodcost, stonecost, requiredxp, increasexp, xpreward)
    {
        this.stoneReward = stoneReward;
        this.goldReward = goldReward;
        this.woodReward = woodReward;
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
            this.stoneReward += increaseReward;
            this.woodReward += increaseReward;
            this.goldReward += increaseReward;
        }

        player.AddResources(this.goldReward, this.stoneReward, this.woodReward);
    }

    public override string GetDescription()
    {
        return string.Format("Gives {0} gold, {1} stone and {2} wood per turn.", this.goldReward, this.stoneReward, this.woodReward);
    }
}
