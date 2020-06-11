using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public enum BlueprintType { Build, Level, Resource }
    
    [System.Serializable]
    public class AchievBlueprint
    {
        public BlueprintType bt;
        public string name;
        public int requiredAmount;
        public AchievType type;
        public GainResource.ResourceType resource;
    }
    //[ConditionalField("NextState", AIState.Idle)] public float IdleTime = 5;
    [SerializeField]
    public AchievBlueprint[] blueprints;
    
    void Start()
    {
        Player player = GetComponent<PlayerManager>().player;

        for (int i = 0; i < blueprints.Length; i++)
        {
            Achievement newAchiev = this.CreateAchievement(blueprints[i]);
            player.achievements.Add(newAchiev);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Achievement CreateAchievement(AchievBlueprint blueprint)
    {
        Achievement newAchiev = null;
        switch (blueprint.bt)
        {
            case BlueprintType.Build:
                newAchiev = new BuiltBuildings(blueprint.name, blueprint.requiredAmount, blueprint.type);
                break;
            case BlueprintType.Level:
                newAchiev = new ReachLevel(blueprint.name, blueprint.requiredAmount, blueprint.type);
                break;
            case BlueprintType.Resource:
                newAchiev = new GainResource(blueprint.resource, blueprint.name, blueprint.requiredAmount, blueprint.type);
                break;
        }

        return newAchiev;
    }
}
