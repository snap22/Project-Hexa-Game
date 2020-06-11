using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiltBuildings : Achievement
{
    private int lastChecked;

    public BuiltBuildings(string name, int requiredAmount, AchievType type) : base(name, requiredAmount, type)
    {
        this.lastChecked = 0;
    }

    public override void Check(Building building)
    {
        /*if (this.IsCompleted())
            return;

        if (building == null)
            return;

        this.lastChecked++;
        if (this.lastChecked >= this.Required)
            this.Complete();
            */

    }

    public override void Check(Player player)
    {
        if (this.IsCompleted())
            return;

        int newAmount = player.NumberOfBuildings;
        if (newAmount <= this.lastChecked)
        {
            return;
        }

        this.lastChecked = newAmount;
        if (this.lastChecked >= this.Required)
            this.Complete();
    }

    

    public override string GetDescription()
    {
        return string.Format("Build {0} buildings", base.Required);
    }
}
