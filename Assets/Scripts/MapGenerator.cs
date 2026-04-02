using UnityEngine;
using System.Collections.Generic;
using System;


public enum RandomType { Random, Seeded, MapOfTheDay };

public class MapGenerator : MonoBehaviour
{
    [Header("Random Data")]
    public RandomType randomType;
    public int seed = 27;

    [Header("TileData")]
    public List<Tile> availableTiles;
    public Tile bossTile;
    public Vector2 bossTileLocation;
    public float tileWidth;
    public float tileLength;
    public int mapCols;
    public int mapRows;

    public Tile[,] grid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set the seed value
        InitializeRandom();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeRandom()
    {
        if (randomType == RandomType.Seeded)
        {
            UnityEngine.Random.InitState(seed);
        } else if (randomType == RandomType.Random)
        {
            UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
        }
        else if (randomType == RandomType.MapOfTheDay)
        {
            UnityEngine.Random.InitState(DateToInt(DateTime.Now.Date));
        }
    }

    public int DateToInt(DateTime date)
    {
        return date.Year + date.Month + date.Day + date.Hour + date.Minute + date.Second;
    }

    public void GenerateMap() 
    {
        // Create the grid array to hold our map
        grid = new Tile[mapCols, mapRows];

        // iterate through and generate all the map tiles
        for (int currentRow = 0; currentRow < mapRows; currentRow++)
        {
            for (int currentCol = 0; currentCol < mapCols; currentCol++)
            {
                Tile tempTile;
                // create a map tile
                if (currentCol == bossTileLocation.x && currentRow == bossTileLocation.y) 
                {
                    tempTile = Instantiate<Tile>(bossTile) as Tile;
                } else
                {
                    tempTile = Instantiate<Tile>(GetRandomTile()) as Tile;
                }

                // Put it in the right position
                Vector3 correctPosition = Vector3.zero;
                correctPosition.z = currentRow * tileWidth;
                correctPosition.x = currentCol * tileLength;
                tempTile.transform.position = correctPosition;

                // Name the tile, so we can easily see if it is in the right spot
                tempTile.name = "Tile (" + currentCol + "," + currentRow + ")";

                // Open the correct doors
                // If in the southmost row, turn off the north door
                if (currentRow == 0)
                {
                    tempTile.doorNorth.SetActive(false);
                }
                // Overwise, if in the northmost row, turn off the south door
                else if (currentRow == mapRows - 1)
                {
                    tempTile.doorSouth.SetActive(false);
                }
                // Otherwise, we are in the middle, so turn off both north and south
                else
                {
                    tempTile.doorNorth.SetActive(false);
                    tempTile.doorSouth.SetActive(false);
                }

                // If eastmost door, open west door
                if (currentCol == mapCols - 1)
                {
                    tempTile.doorWest.SetActive(false);
                }
                // Otherwise, if westmost door, open east door
                else if (currentCol == 0)
                {
                    tempTile.doorEast.SetActive(false);
                }
                // Otherwise, open both east and west
                else
                {
                    tempTile.doorWest.SetActive(false);
                    tempTile.doorEast.SetActive(false);
                }

                // Set the tile's parent in the hierarchy to this gameObject
                tempTile.transform.parent = this.transform;

                // Save it to the grid
                grid[currentCol, currentRow] = tempTile;
            }
        }
    }

    public Tile GetRandomTile()
    {
        int tileNumber = UnityEngine.Random.Range(0, availableTiles.Count);
        return availableTiles[tileNumber];
    }

}
