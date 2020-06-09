using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TerrainModifier : MonoBehaviour
{
    public GameObject selectionPanel;
    public ToolButtonScript toolScript;
    public Tilemap tileMap;
    public Tilemap lockedTileMap;

    public ObjectSpawner spawner;

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

        this.tools = new ToolManager(lockedTileMap, selectionPanel);

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
            //Debug.Log("Original Position = " + pos.ToString());
            
            try
            {

                currentTool.Check(tilePos, tileMap);        // pozrie sa ci je vybraty tile "v poriadku" - ak nie hodi exception

                
                currentTool.Manage(playerManager.player, currentBuilding, tilePos);      //skusi spravit akciu s hracom, ak sa vyskytne problem hodi sa exception
                currentTool.Draw(tilePos, tileMap, currentTile);        //vykona akciu aku treba
                playerManager.UpdateResourcesText();
                currentTool.ShowAnimation(spawner, pos);
                
            }
            catch (OccupiedTileException)
            {
                //Debug.Log("Tile is not empty");
                spawner.SetErrorText(pos, "Tile is not empty");
            }
            catch (NoBuildingException)
            {
                spawner.SetErrorText(pos, "Choose a building in the shop first");
            }
            catch (NotRemovableBuildingException)
            {
                //Debug.Log("You cannot remove this building.");
                spawner.SetErrorText(pos, "You cannot remove this building.");
            }
            catch (LockedTileException)
            {
                //Debug.Log("Tile is locked");
                spawner.SetErrorText(pos, "Tile is locked");
            }
            catch (EmptyTileException)
            {
                //Debug.Log("Tile is empty");
                spawner.SetErrorText(pos, "Tile is empty");
            }
            catch (NoMoneyException)
            {
                //Debug.Log("Not enough money");
                spawner.SetErrorText(pos, "Not enough money");
            }
            catch (NoStoneException)
            {
                //Debug.Log("Not enough stone");
                spawner.SetErrorText(pos, "Not enough stone");
            }
            catch (NoWoodException)
            {
                //Debug.Log("Not enough wood");
                spawner.SetErrorText(pos, "Not enough wood");
            }
            

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
        playerManager.player.AddBuilding(this.currentBuilding, Vector3Int.zero);

        // resetne naspäť
        this.currentBuilding = null;
        this.currentTile = null;
        SetTool(0); //select tool
    }
}
