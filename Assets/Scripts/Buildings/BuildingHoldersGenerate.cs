using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingHoldersGenerate : MonoBehaviour
{

    public TerrainModifier terrainModifier;

    private BuildingFactory factory;

    
    public GameObject prefab;   // prefab pre building holder
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
    }

    

    public void ChangeTile(string name)
    {
        terrainModifier.SetTile(name);
    }
}
