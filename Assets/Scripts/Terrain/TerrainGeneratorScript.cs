using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainGeneratorScript : MonoBehaviour
{

    //  TileMap grid == scale x: 1.2    y: 1.35

    public Tilemap basicTileMap;        // zakladny tile map, všade len trava
    public Tilemap frontLayerTileMap;   //popredný tile map, na nom sa budu ukladať budovy stromy atd..


    public TileBase basic;              //tile pre basic tile map
    public TileBase newTile;
        
    private Vector3 pos;
    private Vector3Int tilePos;
    private bool shouldDo;


    

    void Start()
    {
        GenerateBasicTileMap();
        
    }


    void Update()
    {
        ClickAndShow();
        //DragAndDraw();
    }

    private void ClickAndShow()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pos = Input.mousePosition;
            tilePos = basicTileMap.WorldToCell(Camera.main.ScreenToWorldPoint(pos));
            Debug.Log("Position of tile " + tilePos.ToString());

            frontLayerTileMap.SetTile(tilePos, newTile);

        }
    }

    private void DragAndDraw()
    {
        
        

        if (Input.GetMouseButtonDown(0))
        {
            shouldDo = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            shouldDo = false;
        }

        if (shouldDo)
        {
            pos = Input.mousePosition;
            tilePos = basicTileMap.WorldToCell(Camera.main.ScreenToWorldPoint(pos));

            frontLayerTileMap.SetTile(tilePos, newTile);
        }
    }

    void GenerateBasicTileMap()
    {
        for (int riadok = -100; riadok < 100; riadok++)
        {
            for (int stlpec = -100;  stlpec < 100;  stlpec++)
            {
                
                tilePos = new Vector3Int(riadok , stlpec , 0);
                basicTileMap.SetTile(tilePos, basic);
            }
        }
    }

    
}
