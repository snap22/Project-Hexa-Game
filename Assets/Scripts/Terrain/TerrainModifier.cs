using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TerrainModifier : MonoBehaviour
{
    
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
        this.currentTool = tools.GetTool(0);

        this.currentBuilding = new StarterHouse();
        this.currentTool.Draw(Vector3Int.zero, tileMap, BuildingSelect.Instance.GetBuildingTile(BuildingType.StartingHouse));
    }

    void Update()
    {
        ClickAndDo();
    }
    private void ClickAndDo()
    {
        if (Input.GetMouseButtonDown(0))    //left click        -- build
        {
            pos = Input.mousePosition;
            tilePos = tileMap.WorldToCell(Camera.main.ScreenToWorldPoint(pos));

            //currentTool.Manage(playerManager.player, currentBuilding);      //ak hodi exceptiony - zachytit a osetrit
            currentTool = tools.GetTool(0);
            currentTool.Draw(tilePos, tileMap, currentTile);
            

        }

        if (Input.GetMouseButtonDown(1))    //right click        -- unlock
        {
            pos = Input.mousePosition;
            tilePos = tileMap.WorldToCell(Camera.main.ScreenToWorldPoint(pos));

            //currentTool.Manage(playerManager.player, currentBuilding);      //ak hodi exceptiony - zachytit a osetrit
            currentTool = tools.GetTool(1);
            currentTool.Draw(tilePos, tileMap, currentTile);


        }

    }

    
    // nastavi aktualny tile podla toho co je vybrate na dropdown menu
    public void SetTile() 
    {
        this.currentBuilding = BuildingSelect.Instance.GetBuilding(selection.value);
        this.currentTile = BuildingSelect.Instance.GetBuildingTile(selection.value);
    }


}
