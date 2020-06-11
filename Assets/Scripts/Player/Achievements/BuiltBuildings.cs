using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiltBuildings : Achievement
{
    private int current;

    public BuiltBuildings(string name, int requiredAmount, AchievType type) : base(name, requiredAmount, type)
    {
        this.current = 0;
    }

    public override void Check(Building building)
    {
        if (this.IsCompleted())
            return;

        if (building == null)
            return;

        this.current++;
        if (this.current >= this.Required)
            this.Complete();
            

    }

    public override void Check(Player player)
    {

    }

    

    public override string GetDescription()
    {
        return string.Format("Build {0} buildings", base.Required);
    }
}
