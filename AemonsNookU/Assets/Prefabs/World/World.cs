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
        Level test = new Level01();
        LoadLevel(test);
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
    public Camera cameraPrefab;
    public CameraScript cameraScript
    {
        get
        {
            if (cameraPrefab != null)
            {
                return cameraPrefab.GetComponent<CameraScript>();
            }
            else
            {
                return null;
            }
        }
    }

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





    // --------------- LEVEL -----------------
    #region LEVEL
    public void LoadLevel(Level lev)
    {
        WorldHeight = lev.HEIGHT;
        WorldWidth = lev.WIDTH;
        cameraScript.MapHeight = lev.HEIGHT;
        cameraScript.MapWidth = lev.WIDTH;

        ClearTiles();
        CodeTilesInit();
        TileMapUpdate();

        //WorldTiles[0][3].UpdateTileType(CodeTile.Type.water); // test

        string levelCode = lev.GetLevelCode();
        LoadTileTypesFromLevel(levelCode);
        TileMapUpdate();
    }

    public void LoadTileTypesFromLevel(string input)
    {
        int i = 0;
        char c;
        for (int row = WorldHeight - 1; row >= 0; row--)
        {
            for (int col = 0; col < WorldWidth; col++)
            {
                c = input[i];
                SetTileTypeFromChar(row, col, c);
                i++;
            }
        }
    }

    private void SetTileTypeFromChar(int row, int col, char c)
    {
        CodeTile curTile = WorldTiles[row][col];
        switch (c)
        {
            case 'T':
                curTile.UpdateTileType(CodeTile.Type.tree);
                break;

            case 'S':
                curTile.UpdateTileType(CodeTile.Type.stone);
                break;

            case 'W':
                curTile.UpdateTileType(CodeTile.Type.water);
                break;

            case 'D':
                curTile.UpdateTileType(CodeTile.Type.road);
                break;

            case '1':
                curTile.UpdateTileType(CodeTile.Type.road);
                curTile.isMapEdge = true;
                curTile.mapEdgeId = 1;
                break;

            case '2':
                curTile.UpdateTileType(CodeTile.Type.road);
                curTile.isMapEdge = true;
                curTile.mapEdgeId = 2;
                break;

            case '3':
                curTile.UpdateTileType(CodeTile.Type.road);
                curTile.isMapEdge = true;
                curTile.mapEdgeId = 3;
                break;

            case '4':
                curTile.UpdateTileType(CodeTile.Type.road);
                curTile.isMapEdge = true;
                curTile.mapEdgeId = 4;
                break;

            default:
                break;
        }
    }

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

    private void TileMapUpdate()
    {
        if (codeTilesReady)
        {
            CodeTile curTile;
            for (int h = 0; h < WorldHeight; h++)
            {
                for (int w = 0; w < WorldWidth; w++)
                {
                    curTile = WorldTiles[h][w];
                    SetTileMapTile(w, h, curTile.TileType);
                }
            }
        }
    }
    #endregion


    // --------------- CAMERA -----------------
    #region CAMERA

    #endregion



    // --------------- DEBUG -----------------
    #region DEBUG
    public void SetCodeTileDebugText()
    {
    }

    #endregion


}
