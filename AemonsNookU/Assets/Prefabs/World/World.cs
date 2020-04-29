using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using UnityEngine.Assertions;
using System.Linq;

public class World : MonoBehaviour
{



    // TODO:
    // World class will also be responsible for drawing and maintaining the tiles (tilemap tiles)
    // This should not be updated every step, but only when needed


    #region INTERFACE

    // Awake is always called first
    private void Awake()
    {
        InitGameFramerate();

        Level test = new Level02();  // Todo, later have a menu too choose a level
        LoadLevel(test);

        treeList = new GameObject("Trees");
        treeList.transform.SetParent(this.transform);

        stoneList = new GameObject("Stones");
        stoneList.transform.SetParent(this.transform);

        peepList = new GameObject("Peeps");
        peepList.transform.SetParent(this.transform);
    }


    // Start is called after awake, before the first update
    void Start()
    {
        GrowTrees();
        GrowStone();

        TileMapUpdate();
    }


    // Update is called once per frame
    void Update()
    {
        limitGameFramerate();

        if (peepGenerator.Started == false)
        {
            StartPeepGenerator();
        }

    }
    #endregion


    // ------------- Properties ----------------
    #region PROPERTIES
    public int targetFramerate = 60;
    public Player currentPlayer;
    public int WorldWidth;
    public int WorldHeight;
    private CodeTile[][] WorldTiles;

    // Resources:
    public GameObject treeList;
    public GameObject stoneList;
    public GameObject peepList;

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
    public NotificationCanvas notificationCanvas;

    public DecorationGenerator decorationGenerator;

    private List<Building> buildings = new List<Building>();
    #endregion





    // --------------- NEIGHBOR -----------------
    #region NEIGHBORS

    private void SetTileNeighbors()
    {
        CodeTile curTile;
        for (int h = 0; h < WorldHeight; h++)
        {
            for (int w = 0; w < WorldWidth; w++)
            {
                curTile = WorldTiles[h][w];
                if (h > 0) { curTile.TileBelow = WorldTiles[h - 1][w]; }
                if (h < WorldHeight - 1) { curTile.TileAbove = WorldTiles[h + 1][w]; }
                if (w > 0) { curTile.TileLeft = WorldTiles[h][w - 1]; }
                if (w < WorldWidth - 1) { curTile.TileRight = WorldTiles[h][w + 1]; }
            }
        }
    }
    #endregion





    // --------------- NATURE -----------------
    #region NATURE
    public void GrowTrees()
    {
        foreach (CodeTile t in TreeTiles)
        {
            // adds 1 to 3 trees to tile:
            List<Clickable> newTrees = resourceGenerator.GenerateTreesPos(t.posX, t.posY, 1, 3);
            foreach (var tree in newTrees) { tree.transform.SetParent(treeList.transform); }
            t.Resources.AddRange(newTrees);
        }
    }

    public void GrowStone()
    {
        foreach (CodeTile t in StoneTiles)
        {
            // adds 1 to 3 stones to tile:
            List<Clickable> newStones = resourceGenerator.GenerateStonesPos(t.posX, t.posY, 2, 4);
            foreach (var stone in newStones) { stone.transform.SetParent(stoneList.transform); }
            t.Resources.AddRange(newStones);
        }
    }

    public void GrowFlowers()
    {
    }

    public void ClearTiles()
    {
        topMap.ClearAllTiles();
        midMap.ClearAllTiles();
        botMap.ClearAllTiles();
        codeTilesReady = false;
    }
    #endregion


    // --------------- BUILDINGS -----------------
    #region BUILDINGS
    public List<Building> RetrieveBuildings()
    {
        return this.buildings;
    }

    public void AddBuilding(Building b)
    {
        this.buildings.Add(b);
    }

    public void RemoveBuilding(Building b)
    {
        this.buildings.Remove(b);
    }

    public List<CodeTile> RetrieveBuildingEntranceTilesType(BuildingInfo.Type type)
    {
        List<CodeTile> returnList = new List<CodeTile>();
        var entrancesGroup = (buildings.Where(b => b.Type == type).Select(b => b.Entrances));
        foreach (var group in entrancesGroup)
        {
            returnList.AddRange(group);
        }
        return returnList;
    }

    public List<CodeTile> RetrieveBuildingEntranceTiles()
    {
        List<CodeTile> returnList = new List<CodeTile>();
        var entrancesGroup = (buildings.Select(b => b.Entrances));
        foreach (var group in entrancesGroup)
        {
            returnList.AddRange(group);
        }
        return returnList;
    }


    #endregion




    // --------------- ROADS --------------------
    #region ROADS
    public CodeTile GetRandomRoadTile()
    {
        return RoadTiles[Random.Range(0, RoadTiles.Count)];
    }

    public CodeTile GetRandomExitTile()
    {
        return SpawnTiles[Random.Range(0, SpawnTiles.Count)];
    }

    public List<CodeTile> RetrieveAllRoadTiles()
    {
        return RoadTiles;
    }
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

        // Should have at least two exits:
        Assert.IsTrue(this.SpawnTiles.Count > 1);
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
                curTile.isPath = true;
                RoadTiles.Add(curTile);
                break;

            case '1':
                curTile.UpdateTileType(CodeTile.Type.road);
                curTile.isPath = true;
                curTile.isMapEdge = true;
                curTile.mapEdgeId = 1;
                SpawnTiles.Add(curTile);
                RoadTiles.Add(curTile);
                break;

            case '2':
                curTile.UpdateTileType(CodeTile.Type.road);
                curTile.isPath = true;
                curTile.isMapEdge = true;
                curTile.mapEdgeId = 2;
                SpawnTiles.Add(curTile);
                RoadTiles.Add(curTile);
                break;

            case '3':
                curTile.UpdateTileType(CodeTile.Type.road);
                curTile.isPath = true;
                curTile.isMapEdge = true;
                curTile.mapEdgeId = 3;
                SpawnTiles.Add(curTile);
                RoadTiles.Add(curTile);
                break;

            case '4':
                curTile.UpdateTileType(CodeTile.Type.road);
                curTile.isPath = true;
                curTile.isMapEdge = true;
                curTile.mapEdgeId = 4;
                SpawnTiles.Add(curTile);
                RoadTiles.Add(curTile);
                break;

            case '5':
                curTile.UpdateTileType(CodeTile.Type.road);
                curTile.isPath = true;
                curTile.isMapEdge = true;
                curTile.mapEdgeId = 5;
                SpawnTiles.Add(curTile);
                RoadTiles.Add(curTile);
                break;

            default:
                break;
        }
    }

    #endregion




    // --------------- SYSTEM -----------------
    #region SYSTEM

    public CodeTile TileAt(int posX, int posY)
    {
        if (posX >= 0 && posX < WorldWidth && posY >= 0 && posY < WorldHeight)
        {
            return WorldTiles[posY][posX];
        }
        else
        {
            return null;
        }
    }

    private void limitGameFramerate()
    {
        if (Application.targetFrameRate != targetFramerate)
        {
            Application.targetFrameRate = targetFramerate;
        }
    }

    private void InitGameFramerate()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFramerate;
    }


    private void StartPeepGenerator()
    {
        peepGenerator.SpawnRoadTiles.AddRange(SpawnTiles);
        peepGenerator.AllRoadTiles.AddRange(SpawnTiles);
        peepGenerator.AllRoadTiles.AddRange(RoadTiles);
        peepGenerator.MyWorld = this;
        peepGenerator.Started = true;
    }
    private void UpdatePeepGenerator()
    {
        peepGenerator.SpawnRoadTiles.Clear();
        peepGenerator.SpawnRoadTiles.AddRange(SpawnTiles);
        peepGenerator.AllRoadTiles.Clear();
        peepGenerator.AllRoadTiles.AddRange(SpawnTiles);
        peepGenerator.AllRoadTiles.AddRange(RoadTiles);
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
                curTile.world = this;
                WorldTiles[h][w] = curTile;
            }
        }
        SetTileNeighbors();
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

            case CodeTile.Type.building:
                botMap.SetTile(new Vector3Int(xPos, yPos, 0), grass);
                break;

            default:
                break;
        }
    }

    public void SetTileMapTile(int xPos, int yPos, CodeTile.Type type)
    {
        SetBotMapTile(xPos, yPos, type);
        SetMidMapTile(xPos, yPos, type);
        SetTopMapTile(xPos, yPos, type);
    }

    public void TileMapUpdate()
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
