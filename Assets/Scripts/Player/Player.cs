﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IAnnouncable
{
    public static event Action<IAnnouncable> OnAnnouncement;
    public static event Action<Player> OnPanelUpgrade;

    public PlayerBuildings buildings { get; private set; }
    public AchievementsHolder achievements { get; private set; }
    public LevelHandler levelHandler { get; private set; }

    public int goldAmount { get; private set; }
    public int woodAmount { get; private set; }
    public int stoneAmount { get; private set; }
    public int totalBuilt { get; private set; }
    public int totalRemoved { get; private set; }


    private string removingInfo;
    public int Level
    {
        get { return this.levelHandler.level; }
    }
    public Player()
    {
        buildings = new PlayerBuildings(this);

        this.goldAmount = 100;
        this.woodAmount = 100;
        this.stoneAmount = 100;

        this.levelHandler = new LevelHandler(10, 10);
        this.achievements = new AchievementsHolder();

        this.totalBuilt = 0;
        this.totalRemoved = 0;
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
            OnAnnouncement(this);
        }


        if (building.name == "Starting House")
        {
            OnPanelUpgrade(this);
            return;
        }
            
        this.CheckAchievements(building);
        this.totalBuilt++;
        OnPanelUpgrade(this);
        //Debug.Log("Adding " + building.ToString());

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

        //Debug.Log("Removing " + building.ToString());

        removingInfo = string.Format("  + {0} gold \n   + {1} wood \n   + {2} stone", removedGold, removedWood, removedStone);
        this.totalRemoved++;
        OnPanelUpgrade(this);

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
        CheckAchievements();
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
        CheckAchievements();
    }

    // Prida kamene
    public void AddStone(int amount)
    {
        if (amount <= 0)
            return;
        this.stoneAmount += amount;
        CheckAchievements();
    }

    // Prida xp
    public void AddXp(int amount)
    {
        this.levelHandler.AddXp(amount);
        CheckAchievements();
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
        this.achievements.Check(this, building);
    }

    private void CheckAchievements()
    {
        this.CheckAchievements(null);
    }

    // pre announcementy..

    public string GetAnnouncementName()
    {
        return "Level up";
    }

    public string GetAnnouncementDescription()
    {
        return string.Format("Reached level {0}", this.Level);
    }
}
