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
        if (peepGenerator.Started == false)
        {
            StartPeepGenerator();
        }

    }
    #endregion


    // ------------- Properties ----------------
    #region PROPERTIES
    public int WorldWidth;
    public int WorldHeight;
    private CodeTile[][] WorldTiles;

    public ResourceGenerator resourceGenerator;
    private List<CodeTile> TreeTiles = new List<CodeTile>();
    private List<CodeTile> StoneTiles = new List<CodeTile>();
    private List<CodeTile> RoadTiles = new List<CodeTile>();
    private List<CodeTile> SpawnTiles = new List<CodeTile>();

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

    public PeepGenerator peepGenerator;
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
        foreach (CodeTile t in TreeTiles)
        {
            // adds 1 to 3 trees to tile:
            t.Resources.AddRange(resourceGenerator.GenerateTreesPos(t.posX, t.posY, 1, 3));
        }
    }

    public void GrowStone()
    {
        foreach (CodeTile t in StoneTiles)
        {
            // adds 1 to 3 trees to tile:
            t.Resources.AddRange(resourceGenerator.GenerateStonesPos(t.posX, t.posY, 2, 4));
        }
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
    #endregion


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
        GrowTrees();
        GrowStone();

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
                TreeTiles.Add(curTile);
                break;

            case 'S':
                curTile.UpdateTileType(CodeTile.Type.stone);
                StoneTiles.Add(curTile);
                break;

            case 'W':
                curTile.UpdateTileType(CodeTile.Type.water);
                break;

            case 'D':
                curTile.UpdateTileType(CodeTile.Type.road);
                RoadTiles.Add(curTile);
                break;

            case '1':
                curTile.UpdateTileType(CodeTile.Type.road);
                curTile.isMapEdge = true;
                curTile.mapEdgeId = 1;
                SpawnTiles.Add(curTile);
                break;

            case '2':
                curTile.UpdateTileType(CodeTile.Type.road);
                curTile.isMapEdge = true;
                curTile.mapEdgeId = 2;
                SpawnTiles.Add(curTile);
                break;

            case '3':
                curTile.UpdateTileType(CodeTile.Type.road);
                curTile.isMapEdge = true;
                curTile.mapEdgeId = 3;
                SpawnTiles.Add(curTile);
                break;

            case '4':
                curTile.UpdateTileType(CodeTile.Type.road);
                curTile.isMapEdge = true;
                curTile.mapEdgeId = 4;
                SpawnTiles.Add(curTile);
                break;

            default:
                break;
        }
    }

    #endregion




    // --------------- SYSTEM -----------------
    #region SYSTEM

    private void StartPeepGenerator()
    {
        peepGenerator.SpawnPoints.AddRange(SpawnTiles);
        peepGenerator.Started = true;
    }




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
        SetTileNeighbors();
        codeTilesReady = true;
    }

    private void SetTileNeighbors()
    {
        CodeTile curTile;
        for (int h = 0; h < WorldHeight; h++)
        {
            for (int w = 0; w < WorldWidth; w++)
            {
                curTile = WorldTiles[h][w];
                if (h > 0) { curTile.TileAbove = WorldTiles[h - 1][w]; }
                if (h < WorldHeight - 1) { curTile.TileBelow = WorldTiles[h + 1][w]; }
                if (w > 0) { curTile.TileLeft = WorldTiles[h][w - 1]; }
                if (w < WorldWidth - 1) { curTile.TileRight = WorldTiles[h][w + 1]; }
            }
        }
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
