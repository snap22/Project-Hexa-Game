using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingHoldersGenerate : MonoBehaviour
{

    public TerrainModifier terrainModifier;
    public GameObject prefab;   // prefab pre building holder

    public Text nameText;
    public Text priceText;

    private BuildingFactory factory;
    

    void Start()
    {
        factory = BuildingFactory.Instance;
        
        for (int i = 0; i < factory.buildings.Length; i++)
        {
            if (factory.buildings[i].name == "Starting House")
            {
                continue;
            }
            SetupHolder(factory.buildings[i]);
            
        }



    }

    // pre kazdu instanciu prefabu, t.j buidling holder prida event
    private void SetupHolder(Blueprint blueprint)
    {
        GameObject obj = Instantiate(prefab, transform) as GameObject;
        obj.GetComponentInChildren<Image>().sprite = blueprint.picture;
        obj.GetComponentInChildren<Button>().onClick.AddListener(delegate { ChangeTile(blueprint.name); });
        obj.GetComponentInChildren<Button>().onClick.AddListener(delegate { ShowInfo(blueprint); });
        
    }

    

    public void ChangeTile(string name)
    {
        terrainModifier.SetTile(name);
    }

    public void ShowInfo(Blueprint blueprint)
    {
        nameText.text = string.Format("Name: {0}", blueprint.name);
        priceText.text = string.Format("Price: {0} gold, {1} wood, {2} stone", blueprint.goldCost, blueprint.woodCost, blueprint.stoneCost);
    }
}
