using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building
{

    private LevelHandler lh;
    public int goldCost { get; private set; }
    public int woodCost { get; private set; }
    public int stoneCost { get; private set; }

    public string name { get; private set; }
    public int xpReward { get; private set; }

    // vrati level
    public int Level
    {
        get { return this.lh.level; }
    }
    
    protected Building(string name, int goldCost, int woodCost, int stoneCost, int xpReward) : this(name, goldCost, woodCost, stoneCost, 5, 5, xpReward)
    {
        
    }

    protected Building(string name, int goldCost, int woodCost, int stoneCost, int requiredXp, int increaseXp, int xpReward)
    {
        this.name = name;
        this.goldCost = goldCost;
        this.woodCost = woodCost;
        this.stoneCost = stoneCost;
        this.lh = new LevelHandler(requiredXp, increaseXp);
        this.xpReward = xpReward;
    }

    public abstract void DoStuff(Player player);    //spravi nieco specificke pre kazdu budovu

    public abstract string GetDescription();        //vrati popis budovy

    //prida xp - max level je 5
    protected void AddXp(int amount)
    {
        if (this.Level >= 5)
        {
            return;
        }
        this.lh.AddXp(amount);
    }

}
