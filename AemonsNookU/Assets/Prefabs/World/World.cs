using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class World : MonoBehaviour
{

    // TODO:
    // World class will also be responsible for drawing and maintaining the tiles (tilemap tiles)
    // This should not be updated every step, but only when needed


    #region INTERFACE
    // Start is called before the first frame update
    void Start()
    {
        ClearTiles();
        CodeTilesInit();
        TilesInit();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion


    // ------------- Properties ----------------
    #region PROPERTIES
    public int WorldWidth;
    public int WorldHeight;
    private CodeTile[][] WorldTiles;

    private bool codeTilesReady = false;

    public Tile grass;
    public Tile water;
    public Tile road;
    public Tilemap topMap;
    public Tilemap midMap;
    public Tilemap botMap;

    public PeepGenerator peepGenerator { get; set; }
    #endregion





    // --------------- NEIGHBOR -----------------
    #region NEIGHBORS
    public void SetNeighbors()
    {
    }
    #endregion





    // --------------- NATURE -----------------
    #region NATURE
    public void GrowTrees()
    {
    }
    #endregion

    public void GrowStone()
    {
    }

    public void GrowFlowers()
    {
    }

    public void ClearTiles()
    {
        topMap.ClearAllTiles();
        botMap.ClearAllTiles();
        codeTilesReady = false;
    }



    // --------------- BUILDINGS -----------------
    #region BUILDINGS
    #endregion




    // --------------- SYSTEM -----------------
    #region SYSTEM
    private void DeleteCodeTiles()
    {
        codeTilesReady = false;
    }

    private CodeTile CodeTileInitPos(int xPos, int yPos)
    {
        CodeTile curTile = new CodeTile();
        curTile.posX = xPos;
        curTile.posY = yPos;
        return curTile;
    }

    private void CodeTilesInit()
    {
        WorldTiles = new CodeTile[WorldHeight][];
        CodeTile curTile;
        for (int h = 0; h < WorldHeight; h++)
        {
            WorldTiles[h] = new CodeTile[WorldWidth]; 
            for (int w = 0; w < WorldWidth; w++)
            {
                curTile = CodeTileInitPos(w, h);
                curTile.UpdateTileType(CodeTile.Type.grass);
                WorldTiles[h][w] = curTile;
            }
        }
        codeTilesReady = true;
    }



    private void SetTopMapTile(int xPos, int yPos, CodeTile.Type type)
    {
        bool clearTile = false;
        switch (type)
        {
            case CodeTile.Type.grass:
                clearTile = true;
                break;

            case CodeTile.Type.road:
                clearTile = true;
                break;

            case CodeTile.Type.water:
                clearTile = true;
                break;

            default:
                clearTile = true;
                break;
        }
        if (clearTile)
        {
            topMap.SetTile(new Vector3Int(xPos, yPos, 0), null);
        }
    }
    private void SetMidMapTile(int xPos, int yPos, CodeTile.Type type)
    {
        bool clearTile = false;
        switch (type)
        {
            case CodeTile.Type.grass:
                clearTile = true;
                break;

            case CodeTile.Type.road:
                clearTile = true;
                break;

            case CodeTile.Type.water:
                clearTile = true;
                break;

            default:
                clearTile = true;
                break;
        }
        if (clearTile)
        {
            midMap.SetTile(new Vector3Int(xPos, yPos, 0), null);
        }
    }
    private void SetBotMapTile(int xPos, int yPos, CodeTile.Type type)
    {
        // Bottom map MUST have a tile (no clearing)
        switch (type)
        {
            case CodeTile.Type.grass:
                botMap.SetTile(new Vector3Int(xPos, yPos, 0), grass);
                break;

            case CodeTile.Type.road:
                botMap.SetTile(new Vector3Int(xPos, yPos, 0), road);
                break;

            case CodeTile.Type.water:
                botMap.SetTile(new Vector3Int(xPos, yPos, 0), water);
                break;

            default:
                break;
        }
    }

    private void SetTileMapTile(int xPos, int yPos, CodeTile.Type type)
    {
        SetBotMapTile(xPos, yPos, type);
        SetMidMapTile(xPos, yPos, type);
        SetTopMapTile(xPos, yPos, type);
    }

    private void TilesInit()
    {
        if (codeTilesReady)
        {
            CodeTile curTile;
            for (int h = 0; h < WorldHeight; h++)
            {
                for (int w = 0; w < WorldWidth; w++)
                {
                    curTile = WorldTiles[h][w];
                    Debug.Log($"Setting tile as position ({w},{h}) with type={curTile.TileType}");
                    SetTileMapTile(w, h, curTile.TileType);
                }
            }
        }
    }


    #endregion



    // --------------- DEBUG -----------------
    #region DEBUG
    public void SetCodeTileDebugText()
    {
    }

    #endregion


}
