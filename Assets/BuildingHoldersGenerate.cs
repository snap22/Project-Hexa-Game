using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingHoldersGenerate : MonoBehaviour
{
    

    private BuildingFactory factory;

    
    public GameObject shit;
    void Start()
    {
        factory = BuildingFactory.Instance;
        
        /*for (int i = 0; i < holders.Length; i++)
        {
            if (i >= factory.buildings.Length)
            {
                holders[i].SetActive(false);
            }
            else
            {
                SetupObject(holders[i], factory.buildings[i]);
            }

            
        }*/

        for (int i = 0; i < factory.buildings.Length; i++)
        {
            Setup(factory.buildings[i], i);
        }

        
    }

    private void Setup(Blueprint blueprint, int index)
    {
        //GameObject obj = shit;
        GameObject obj = Instantiate(shit, transform) as GameObject;
        obj.GetComponentInChildren<Image>().sprite = blueprint.picture;
        obj.GetComponentInChildren<Button>().onClick.AddListener(delegate { ChangeTile(blueprint.name); });
        //Instantiate(obj, transform);
    }

    

    public void ChangeTile(string name)
    {
        Debug.Log(name);
    }
}
