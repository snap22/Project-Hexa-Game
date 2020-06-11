using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachLevel : Achievement
{

    private int currentLevel;
    public ReachLevel(string name, int requiredAmount, AchievType type) : base(name, requiredAmount, type)
    {
        this.currentLevel = 1;
    }

    public override void Check(Building building)
    {
    }

    public override void Check(Player player)
    {
        
        if (this.IsCompleted())
            return;

        this.currentLevel = player.levelHandler.level;
        if (this.currentLevel >= this.Required)
            this.Complete();
            
    }

    public override string GetDescription()
    {
        return string.Format("Reach level {0}", this.Required);
    }
}
