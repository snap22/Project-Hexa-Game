using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainGeneratorScript : MonoBehaviour
{

    //  TileMap grid == scale x: 1.2    y: 1.35

    public Tilemap basicTileMap;        // zakladny tile map, všade len trava
    public Tilemap frontLayerTileMap;   //popredný tile map, na nom sa budu ukladať budovy stromy atd..
    public Tilemap lockedTileMap;

    public TileBase basic;              //tile pre basic tile map
    public TileBase newTile;        //test use only

    public TileBase lockedTile;
    

    public TileBase[] tiles;
        
    private Vector3 pos;
    private Vector3Int tilePos;
    private bool shouldDo;

    int size = 100;
    int halfSize = 50;
    

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
        if (Input.GetMouseButtonDown(0))    //left click
        {
            pos = Input.mousePosition;
            tilePos = basicTileMap.WorldToCell(Camera.main.ScreenToWorldPoint(pos));
            //Debug.Log("Position of tile " + tilePos.ToString());

            //frontLayerTileMap.SetTile(tilePos, newTile);
            lockedTileMap.SetTile(tilePos, null);
            
        }if (Input.GetMouseButtonDown(1))   //right click
        {
            pos = Input.mousePosition;
            tilePos = basicTileMap.WorldToCell(Camera.main.ScreenToWorldPoint(pos));
            //Debug.Log("Position of tile " + tilePos.ToString());

            //frontLayerTileMap.SetTile(tilePos, newTile);
            
            TileBase selectedTile = lockedTileMap.GetTile(tilePos);
            if (selectedTile == null)
            {
                if (frontLayerTileMap.GetTile(tilePos) == null)
                    frontLayerTileMap.SetTile(tilePos, newTile);
                else
                    Debug.Log("This tile is not empty");
            } else
            {
                Debug.Log("Tile is locked");
            }
            
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
        for (int row = 0; row < size; row++)
        {
            for (int column = 0;  column < size;  column++)
            {
                
                tilePos = new Vector3Int(row - halfSize, column - halfSize, 0);
                //basicTileMap.SetTile(tilePos, TestGen(row - halfSize, column - halfSize));
                basicTileMap.SetTile(tilePos, basic);
                lockedTileMap.SetTile(tilePos, lockedTile);
            }
        }

        frontLayerTileMap.SetTile(Vector3Int.zero, newTile);
    }

    private TileBase TestGen(int x, int y)
    {
        float xCoord = (float)x / size;
        float yCoord = (float)y / size;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        //Debug.Log(sample);
        return ChooseTile(sample);
    }

    // vrati tile podla zadaneho cisla --> cierna magia
    private TileBase ChooseTile(float number)
    {
        if (number <= 0.3f)
        {
            return tiles[0];
        }if (number <= 0.35f)
        {
            return tiles[1];
        }if (number <= 0.4f)
        {
            return tiles[2];
        }if (number <= 0.45f)
        {
            return tiles[3];
        }
        if (number <= 0.47f)
        {
            return tiles[0];
        }
        if (number <= 0.49f)
        {
            return tiles[4];
        }
        
        if (number <= 5f)
        {
            
            return tiles[2];
        }

        return null;
       
    }

    
}
