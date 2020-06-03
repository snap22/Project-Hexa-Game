using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TerrainModifier : MonoBehaviour
{
    
    public Tilemap tileMap;
    private TileBase currentTile;

    private ITool currentTool;

    private Vector3 pos;
    private Vector3Int tilePos;

    public Dropdown selection;
    public PlayerManager playerManager;
    private Building currentBuilding;

    void Start()
    {
        this.currentTool = new BuildTool();
        
    }

    void Update()
    {
        ClickAndDo();
    }
    private void ClickAndDo()
    {
        if (Input.GetMouseButtonDown(0))    //left click        -- unlock
        {
            pos = Input.mousePosition;
            tilePos = tileMap.WorldToCell(Camera.main.ScreenToWorldPoint(pos));
            currentTool.Draw(tilePos, tileMap, currentTile);
            currentTool.Manage(playerManager.player, currentBuilding);

        }

    }

    
    // nastavi aktualny tile podla toho co je vybrate na dropdown menu
    public void SetTile() 
    {
        this.currentBuilding = BuildingSelect.Instance.GetBuilding(selection.value);
        this.currentTile = BuildingSelect.Instance.GetBuildingTile(selection.value);
    }
}
