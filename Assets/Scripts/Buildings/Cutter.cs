using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cutter : Building
{
    private int woodReward;
    public Cutter() : base("Cutter", 80, 50, 50, 10, 10, 2)
    {
        this.woodReward = 2;
    }
    public override void DoStuff(Player player)
    {
        try
        {
            base.AddXp(1);
        }
        catch (LevelUpException)
        {
            this.woodReward += 2;
        }

        player.AddWood(this.woodReward);

    }

    public override string GetDescription()
    {
        return "Cutter";
    }
}
