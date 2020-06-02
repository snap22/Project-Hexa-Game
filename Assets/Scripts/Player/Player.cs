using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    PlayerBuildings buildings { get; }

    public int goldAmount { get; private set; }
    public int woodAmount { get; private set; }
    public int stoneAmount { get; private set; }
    public int level { get; private set; }
    public int currentXp { get; private set; }
    public int requiredtXp { get; private set; }


    public Player()
    {
        buildings = new PlayerBuildings(this);

        this.goldAmount = 0;
        this.woodAmount = 0;
        this.stoneAmount = 0;

        this.level = 1;
        this.currentXp = 0;
        this.requiredtXp = 10;
    }

    // Prida budovu do zoznamu, ak hrac nema dostatok penazi, dreva alebo kamena tak vrati exception
    public void AddBuilding(Building building)
    {
        this.buildings.Add(building);
        if (this.goldAmount < building.goldCost)
            throw new NoMoneyException();
        if (this.stoneAmount < building.stoneCost)
            throw new NoStoneException();
        if (this.woodAmount < building.woodCost)
            throw new NoWoodException();

        this.goldAmount -= building.goldCost;
        this.stoneAmount -= building.stoneCost;
        this.woodAmount -= building.woodCost;

    }


    //Vymaze budovu a vrati hracovi tretinu ceny budovy, a polovicu dreva a kamenov ktore vynalozil na kupu budovy 
    public void RemoveBuilding(Building building)
    {
        this.buildings.Remove(building);

        this.goldAmount += building.goldCost / 3;
        this.stoneAmount += building.stoneCost / 2;
        this.woodAmount += building.woodCost / 2;

    }

    // Prida goldy
    public void AddGold(int amount)
    {
        if (amount <= 0)
            return;
        this.goldAmount += amount;
    }

    // Prida drevo
    public void AddWood(int amount)
    {
        if (amount <= 0)
            return;
        this.woodAmount += amount; 
    }

    // Prida kamene
    public void AddStone(int amount)
    {
        if (amount <= 0)
            return;
        this.stoneAmount += amount;
    }

    // Prida xp
    public void AddXp(int amount)
    {
        if (amount <= 0)
            return;
        this.currentXp += amount;

        while (currentXp >= requiredtXp)
        {
            LevelUp();
        }
    }

    public void AddResources(int gold, int stone, int wood, int xp = 0)
    {
        AddGold(gold);
        AddStone(stone);
        AddWood(wood);
        AddXp(xp);
    }

    // Zvysi level
    private void LevelUp()
    {
        if (currentXp >= this.requiredtXp)
        {
            this.level++;
            this.currentXp -= this.requiredtXp;
            this.requiredtXp += 10;
        }
    }
    
    
}
