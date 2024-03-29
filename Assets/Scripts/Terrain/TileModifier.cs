﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileModifier
{
    List<Vector3Int> bannedEven;
    List<Vector3Int> bannedOdd;
    public TileModifier()
    {

    }

    public List<Vector3Int> GetNeighbours(Vector3Int tilePosition)
    {
        List<Vector3Int> neighbours = new List<Vector3Int>();
        int x = tilePosition.x;
        int y = tilePosition.y;
        int z = tilePosition.z;

        if (y % 2 == 0)
        {
            // susedia zhora
            neighbours.Add(new Vector3Int(x - 1, y + 1, z));
            neighbours.Add(new Vector3Int(x, y + 1, z));
            // susedia zbokov, rovnaky riadok
            neighbours.Add(new Vector3Int(x - 1, y, z));
            neighbours.Add(new Vector3Int(x + 1, y, z));
            //susedia zdola
            neighbours.Add(new Vector3Int(x - 1, y - 1, z));
            neighbours.Add(new Vector3Int(x, y - 1, z));
        } else
        {
            // susedia zhora
            neighbours.Add(new Vector3Int(x, y + 1, z));
            neighbours.Add(new Vector3Int(x + 1, y + 1, z));
            // susedia zbokov, rovnaky riadok
            neighbours.Add(new Vector3Int(x - 1, y, z));
            neighbours.Add(new Vector3Int(x + 1, y, z));
            //susedia zdola
            neighbours.Add(new Vector3Int(x, y - 1, z));
            neighbours.Add(new Vector3Int(x + 1, y - 1, z));
        }
        

        return neighbours;
    }

    public List<Vector3Int> GetNeighbours(Vector3Int tilePosition, int radius)
    {
        List<Vector3Int> neighbours = new List<Vector3Int>();
        int x = tilePosition.x;
        int y = tilePosition.y;
        int z = tilePosition.z;

        Vector3Int newPos;

        for (int i = x - radius; i <= x + radius; i++)
        {
            for (int j = y - radius; j <= y + radius; j++)
            {
                
                newPos = new Vector3Int(i, j, z);
                
                neighbours.Add(newPos);
                
                
            }
        }

        return neighbours;
    }

   
   
    

    // TODO - unlocknut 6 susedov v zavislosti od smeru - zhora, zdola, zlava, zprava, okolo

}
