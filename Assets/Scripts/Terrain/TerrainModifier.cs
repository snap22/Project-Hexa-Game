using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TerrainModifier : MonoBehaviour
{
    public ToolButtonScript toolScript;
    public Tilemap tileMap;
    public Tilemap lockedTileMap;

    [SerializeField]
    private TileBase currentTile;

    private ITool currentTool;
    private ToolManager tools;

    private Vector3 pos;
    private Vector3Int tilePos;

    public PlayerManager playerManager;
    private Building currentBuilding;

    private BuildingFactory factory;

    void Start()
    {
        factory = BuildingFactory.Instance;

        this.tools = new ToolManager(lockedTileMap);

        this.BuildAStarterHouseAtTheBeginning();
    }

    void Update()
    {
        ClickAndDo();
    }
    private void ClickAndDo()
    {
        if (Input.GetMouseButtonDown(0))    //left click        
        {
            if (EventSystem.current.IsPointerOverGameObject())  // ak je kliknute na UI tak nic nespravi
                return;

            pos = Input.mousePosition;
            tilePos = tileMap.WorldToCell(Camera.main.ScreenToWorldPoint(pos));

            //currentTool.Manage(playerManager.player, currentBuilding);      //ak hodi exceptiony - zachytit a osetrit
            //currentTool = tools.GetTool(0);
            currentTool.Draw(tilePos, tileMap, currentTile);

            
        }


    }

    
    // nastavi aktualny tile podla toho co je kliknute
    public void SetTile(string name) 
    {
        this.currentBuilding = factory.GetBuilding(name);
        this.currentTile = factory.GetTile(name);
        SetTool(1); //nastavi na building tool automaticky
    }


    public void SetTool(int index)
    {
        this.currentTool = this.tools.GetTool(index);
        toolScript.SetButtonActive(index);
    }



    private void BuildAStarterHouseAtTheBeginning()
    {
        this.SetTile("Starting House");
        this.currentTool.Draw(Vector3Int.zero, tileMap, this.currentTile);
        playerManager.player.AddBuilding(this.currentBuilding);

        // resetne naspäť
        this.currentBuilding = null;
        this.currentTile = null;
        SetTool(0); //select tool
    }
}
