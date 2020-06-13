using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsHolder
{
    public static event Action<Achievement> OnAchievementCompleted;


    private List<Achievement> achievements;

    public AchievementsHolder()
    {
        this.achievements = new List<Achievement>();
        

        this.CreateAchievements();
    }

    private void CreateAchievements()
    {
        // build achievement
        this.Add(new BuiltBuildings("Just getting started", 1, AchievType.Bronze));
        this.Add(new BuiltBuildings("Building a small village", 10, AchievType.Bronze));
        this.Add(new BuiltBuildings("Building a bigger village", 25, AchievType.Bronze));
        this.Add(new BuiltBuildings("Building a small town", 50, AchievType.Silver));
        this.Add(new BuiltBuildings("Building a bigger town", 100, AchievType.Silver));
        this.Add(new BuiltBuildings("Building a city", 500, AchievType.Gold));
        this.Add(new BuiltBuildings("Building a metropolis", 1000, AchievType.Gold));
        // level achievement
        this.Add(new ReachLevel("Level 5", 5, AchievType.Bronze));
        this.Add(new ReachLevel("Level 10", 10, AchievType.Bronze));
        this.Add(new ReachLevel("Level 25", 25, AchievType.Silver));
        this.Add(new ReachLevel("Level 50", 50, AchievType.Silver));
        this.Add(new ReachLevel("Level 100", 100, AchievType.Gold));
        this.Add(new ReachLevel("Level 150", 150, AchievType.Gold));
        // gold achievement
        this.Add(new GainResource(GainResource.ResourceType.Gold, "First money", 500, AchievType.Bronze));
        this.Add(new GainResource(GainResource.ResourceType.Gold, "Don't get cocky", 1000, AchievType.Bronze));
        this.Add(new GainResource(GainResource.ResourceType.Gold, "Humble style", 2500, AchievType.Silver));
        this.Add(new GainResource(GainResource.ResourceType.Gold, "Looks promising", 5000, AchievType.Silver));
        this.Add(new GainResource(GainResource.ResourceType.Gold, "Getting rich", 10000, AchievType.Silver));
        this.Add(new GainResource(GainResource.ResourceType.Gold, "Living a bourgeois lifestyle", 100000, AchievType.Gold));
        this.Add(new GainResource(GainResource.ResourceType.Gold, "A freaking millionaire!", 1000000, AchievType.Gold));
        // wood achievement
        this.Add(new GainResource(GainResource.ResourceType.Wood, "Getting some wood", 500, AchievType.Bronze));
        this.Add(new GainResource(GainResource.ResourceType.Wood, "Don't get cocky", 1000, AchievType.Bronze));
        this.Add(new GainResource(GainResource.ResourceType.Wood, "Humble style", 2500, AchievType.Silver));
        this.Add(new GainResource(GainResource.ResourceType.Wood, "Looks promising", 5000, AchievType.Silver));
        this.Add(new GainResource(GainResource.ResourceType.Wood, "Getting supplied", 10000, AchievType.Silver));
        this.Add(new GainResource(GainResource.ResourceType.Wood, "Woody amount", 100000, AchievType.Gold));
        this.Add(new GainResource(GainResource.ResourceType.Wood, "A freaking millionaire!", 1000000, AchievType.Gold));
        // gold achievement
        this.Add(new GainResource(GainResource.ResourceType.Stone, "First rocks", 500, AchievType.Bronze));
        this.Add(new GainResource(GainResource.ResourceType.Stone, "Don't get cocky", 1000, AchievType.Bronze));
        this.Add(new GainResource(GainResource.ResourceType.Stone, "Humble style", 2500, AchievType.Silver));
        this.Add(new GainResource(GainResource.ResourceType.Stone, "Looks promising", 5000, AchievType.Silver));
        this.Add(new GainResource(GainResource.ResourceType.Stone, "Getting supplied", 10000, AchievType.Silver));
        this.Add(new GainResource(GainResource.ResourceType.Stone, "Finally can get stoned", 100000, AchievType.Gold));
        this.Add(new GainResource(GainResource.ResourceType.Stone, "A freaking millionaire!", 1000000, AchievType.Gold));

    }

    public void Add(Achievement achievement)
    {
        if (achievement == null)
            return;

        this.achievements.Add(achievement);
    }

    public void Check(Player player, Building building)
    {
        //List<Achievement>  completed = new List<Achievement>();
        
        for (int i = 0; i < achievements.Count; i++)
        {
            if (achievements[i].IsCompleted())
                continue;

            try
            {
                this.achievements[i].Check(player);
                this.achievements[i].Check(building);
            }
            catch(AchievementCompletedException)
            {
                
                if (OnAchievementCompleted != null)
                {
                    OnAchievementCompleted(this.achievements[i]);
                }
            }
            
        }

        
    }

   

    public Achievement[] GetAchievements()
    {
        Achievement[] achievs = new Achievement[this.achievements.Count];
        this.achievements.CopyTo(achievs);
        return achievs;
    }
    
}
