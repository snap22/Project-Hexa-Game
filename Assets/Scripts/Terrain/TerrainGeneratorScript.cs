﻿using System.Collections;
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

    TileModifier tm;
    

    void Start()
    {
        tm = new TileModifier();
        GenerateBasicTileMap();
        
    }


    private void UnlockNeighbours(Vector3Int position)
    {
        
        List<Vector3Int> neighbours = tm.GetNeighbours(position);
        foreach (Vector3Int neighbour in neighbours)
        {
            lockedTileMap.SetTile(neighbour, null);
        }
        lockedTileMap.SetTile(position, null);
    }

    // vygeneruje tilemap
    void GenerateBasicTileMap()
    {
        for (int row = 0; row < size; row++)
        {
            for (int column = 0;  column < size;  column++)
            {
                
                tilePos = new Vector3Int(row - halfSize, column - halfSize, 0);
                basicTileMap.SetTile(tilePos, basic);
                lockedTileMap.SetTile(tilePos, lockedTile);
            }
        }
        UnlockNeighbours(Vector3Int.zero);
        //frontLayerTileMap.SetTile(Vector3Int.zero, newTile);
        
    }


    



    
}   //koniec triedy



// trash
/*
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
    */
