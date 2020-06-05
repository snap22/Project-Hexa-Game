using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGiving : Building
{
    private int stoneReward;
    private int increaseReward;

    public StoneGiving(string name, int goldcost, int woodcost, int stonecost, int requiredxp, int increasexp, int xpreward, int stoneReward, int increaseRewardAmount) :
        base(name, goldcost, woodcost, stonecost, requiredxp, increasexp, xpreward)
    {
        this.stoneReward = stoneReward;
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
        }

        player.AddStone(this.stoneReward);
    }

    public override string GetDescription()
    {
        return string.Format("Gives {0} stone per turn.", this.stoneReward);
    }
}
