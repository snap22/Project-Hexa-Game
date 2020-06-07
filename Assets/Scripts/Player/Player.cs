using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public PlayerBuildings buildings { get; private set; }
    public LevelHandler levelHandler { get; private set; }

    public int goldAmount { get; private set; }
    public int woodAmount { get; private set; }
    public int stoneAmount { get; private set; }

    

    public Player()
    {
        buildings = new PlayerBuildings(this);

        this.goldAmount = 5000;
        this.woodAmount = 5000;
        this.stoneAmount = 5000;

        this.levelHandler = new LevelHandler(10, 10);
    }

    

    // Prida budovu do zoznamu, ak hrac nema dostatok penazi, dreva alebo kamena tak vrati exception
    public void AddBuilding(Building building, Vector3Int position)
    {
        this.buildings.Add(building, position);
        if (this.goldAmount < building.goldCost)
            throw new NoMoneyException();
        if (this.stoneAmount < building.stoneCost)
            throw new NoStoneException();
        if (this.woodAmount < building.woodCost)
            throw new NoWoodException();

        this.goldAmount -= building.goldCost;
        this.stoneAmount -= building.stoneCost;
        this.woodAmount -= building.woodCost;

        try
        {
            AddXp(building.xpReward);
        }
        catch (LevelUpException)
        {
            Debug.Log("Leveled up!");
        }

        Debug.Log("Adding " +  building.ToString());
    }


    //Vymaze budovu a vrati hracovi tretinu ceny budovy, a polovicu dreva a kamenov ktore vynalozil na kupu budovy 
    public void RemoveBuilding(Vector3Int position)
    {
        Building building = this.buildings.Remove(position);
        
        if (building == null)
            return;

        this.goldAmount += building.goldCost / 3;
        this.stoneAmount += building.stoneCost / 2;
        this.woodAmount += building.woodCost / 2;

        Debug.Log("Removing " + building.ToString());


    }

    public Building GetBuilding(Vector3Int position)
    {
        return this.buildings.GetBuilding(position);
    }

    public void UpdateBuildings()
    {
        this.buildings.UpdateBuildings();
    }

    // Prida goldy
    public void AddGold(int amount)
    {
        if (amount <= 0)
            return;
        this.goldAmount += amount;
    }

    public void RemoveGold(int amount)
    {
        if (amount <= 0)
            return;
        if (amount > this.goldAmount)
        {
            throw new NoMoneyException();
        }
        this.goldAmount -= amount;
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
        this.levelHandler.AddXp(amount);
    }

    public void AddResources(int gold, int stone, int wood, int xp = 0)
    {
        AddGold(gold);
        AddStone(stone);
        AddWood(wood);
        AddXp(xp);
    }

    
    
}
