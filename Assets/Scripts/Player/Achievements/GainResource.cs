using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainResource : Achievement
{
    public enum ResourceType { Gold, Wood, Stone};
    private int lastCheckAmount;
    private ResourceType resource;

    public GainResource(ResourceType resource, string name, int requiredAmount, AchievType type) : base(name, requiredAmount, type)
    {
        this.lastCheckAmount = 0;
        this.resource = resource;
    }

    public override void Check(Building building)
    {
    }

    public override void Check(Player player)
    {
        int newAmount = 0;
        switch (resource)
        {
            case ResourceType.Gold:
                newAmount = player.goldAmount;
                break;
            case ResourceType.Wood:
                newAmount = player.woodAmount; 
                break;
            case ResourceType.Stone:
                newAmount = player.stoneAmount;
                break;
        }

        if (newAmount <= this.lastCheckAmount)
            return;

        this.lastCheckAmount = newAmount;
        if (this.lastCheckAmount >= this.Required)
            this.Complete();

    }

    public override string GetDescription()
    {
        switch (resource)
        {
            case ResourceType.Gold:
                return string.Format("Gain {0} gold.", this.Required);
            case ResourceType.Wood:
                return string.Format("Gain {0} wood.", this.Required);
            case ResourceType.Stone:
                return string.Format("Gain {0} stone.", this.Required);
        }

        return "";
    }
}
