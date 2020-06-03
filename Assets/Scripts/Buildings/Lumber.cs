using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Lumber : Building
{
    private int woodReward;
    public Lumber() : base("Lumber", 20, 20, 0, 1)
    {
        this.woodReward = 1;
    }
    public override void DoStuff(Player player)
    {
        try
        {
            base.AddXp(1);
        }
        catch (LevelUpException)
        {
            this.woodReward = base.Level;
        }

        player.AddWood(this.woodReward);

    }

    public override string GetDescription()
    {
        return "Lumber";
    }



    
}
