using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public PlayerBuildings buildings { get; private set; }
    public AchievementsHolder achievements { get; private set; }
    public LevelHandler levelHandler { get; private set; }

    public int goldAmount { get; private set; }
    public int woodAmount { get; private set; }
    public int stoneAmount { get; private set; }


    private string removingInfo;
    public int Level
    {
        get { return this.levelHandler.level; }
    }
    public Player()
    {
        buildings = new PlayerBuildings(this);

        this.goldAmount = 5000;
        this.woodAmount = 5000;
        this.stoneAmount = 5000;

        this.levelHandler = new LevelHandler(10, 10);
        this.achievements = new AchievementsHolder();
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

        
    }

    

    //Vymaze budovu a vrati hracovi tretinu ceny budovy, a polovicu dreva a kamenov ktore vynalozil na kupu budovy 
    public void RemoveBuilding(Vector3Int position)
    {
        Building building = this.buildings.Remove(position);
        
        if (building == null)
            return;

        int removedGold = building.goldCost / 3;
        int removedStone = building.stoneCost / 2;
        int removedWood = building.woodCost / 2;

        this.goldAmount += removedGold;
        this.stoneAmount += removedStone;
        this.woodAmount += removedWood;

        Debug.Log("Removing " + building.ToString());

        removingInfo = string.Format("  + {0} gold \n   + {1} wood \n   + {2} stone", removedGold, removedWood, removedStone);

        
    }

    public string GetRemovingInfo()
    {
        return removingInfo;
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
        //CheckAchievements();
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
        //CheckAchievements();
    }

    // Prida kamene
    public void AddStone(int amount)
    {
        if (amount <= 0)
            return;
        this.stoneAmount += amount;
        //CheckAchievements();
    }

    // Prida xp
    public void AddXp(int amount)
    {
        this.levelHandler.AddXp(amount);
        //CheckAchievements();
    }

    public int NumberOfBuildings
    {
         get { return this.buildings.Count; }
    }
    public void AddResources(int gold, int stone, int wood, int xp = 0)
    {
        AddGold(gold);
        AddStone(stone);
        AddWood(wood);
        AddXp(xp);
    }



    private void CheckAchievements(Building building)
    {
        /*try
        {
            this.achievements.Check(this, building);
        }
        catch (AchievementCompletedException)
        {
            Debug.Log("Completed achievement.");

        }*/

        this.achievements.Check(this, building);
    }

    private void CheckAchievements()
    {
        this.CheckAchievements(null);
    }
}
