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

    public Dropdown selection;
    public PlayerManager playerManager;
    private Building currentBuilding;

    void Start()
    {
        this.tools = new ToolManager(lockedTileMap);
        SetTool(1);    //build tool

        this.currentBuilding = new StarterHouse();
        this.currentTool.Draw(Vector3Int.zero, tileMap, BuildingSelect.Instance.GetBuildingTile(BuildingType.StartingHouse));
        playerManager.player.AddBuilding(new StarterHouse());

        SetTool(0); //select tool
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

    
    // nastavi aktualny tile podla toho co je vybrate na dropdown menu
    public void SetTile() 
    {
        this.currentBuilding = BuildingSelect.Instance.GetBuilding(selection.value);
        this.currentTile = BuildingSelect.Instance.GetBuildingTile(selection.value);
    }


    public void SetTool(int index)
    {
        this.currentTool = this.tools.GetTool(index);
        toolScript.SetButtonActive(index);
    }

}
