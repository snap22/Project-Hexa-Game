using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SelectionTool : ITool
{
    private GameObject panel;
    private SelectionPanelScript selectionPanel;
    Camera cam;

    private Vector3 offSet;

    float screenWidth;
    float screenHeight;

    float maxChangeX;
    float maxChangeY;

    public SelectionTool(GameObject selectionPanel)
    {
        this.panel = selectionPanel;
        this.selectionPanel = selectionPanel.GetComponent<SelectionPanelScript>();
        RectTransform rect = this.panel.GetComponent<RectTransform>();
        cam = Camera.main;
        //this.offSet = new Vector3(100f, 300f, 0f);
        screenWidth = Screen.width - 150;
        screenHeight = Screen.height - 200;
        this.offSet = new Vector3(rect.rect.width + 30f, rect.rect.height + 30f, 0f);

        maxChangeX = screenWidth - offSet.x;
        maxChangeY = screenHeight - offSet.y;
    }

    public void Check(Vector3Int position, Tilemap tilemap)
    {
        TileBase tile = tilemap.GetTile(position);
        if (tile == null)
            throw new EmptyTileException();
    }

    public void Draw(Vector3Int position, Tilemap tilemap, TileBase tile)
    {
        Vector3 clickedPosition = cam.WorldToScreenPoint(tilemap.CellToWorld(position));
        
        this.panel.transform.position = CalculatePosition(clickedPosition);
        this.panel.SetActive(true);

    }

    public void Manage(Player player, Building building, Vector3Int position)
    {
        // SHOW BUILDING
        Building selectedBuilding = player.GetBuilding(position);
        if (selectedBuilding == null)
            throw new NoBuildingException();


        this.selectionPanel.nameText.text = selectedBuilding.name;
        this.selectionPanel.descriptionText.text = selectedBuilding.GetDescription();
        this.selectionPanel.currentLevel.text = selectedBuilding.Level.ToString();

        int requiredXp = selectedBuilding.RequiredXp;
        int currentXp = selectedBuilding.CurrentXp; ;
        this.selectionPanel.progressBar.Upgrade(curr: currentXp, max: requiredXp);

    }


    Vector3 CalculatePosition(Vector3 clicked)
    {
        Vector3 newPosition = clicked + offSet;

        if (newPosition.x  >= this.screenWidth)
            newPosition.x = maxChangeX;
        

        if (newPosition.y >= this.screenHeight)
            newPosition.y = maxChangeY;
        
        return newPosition;

        
            
    }
}
