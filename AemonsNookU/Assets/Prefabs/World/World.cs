using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    // TODO:
    // World class will also be responsible for drawing and maintaining the tiles (tilemap tiles)
    // This should not be updated every step, but only when needed


    #region INTERFACE
    // Start is called before the first frame update
    void Start()
    {
        
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
    private Tile[][] WorldTiles;
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
    }



    // --------------- BUILDINGS -----------------
    #region BUILDINGS
    #endregion




    // --------------- SYSTEM -----------------
    #region SYSTEM
    private void DeleteTiles()
    {
    }

    private Tile InitTileAt(int xPos, int yPos)
    {
        Tile curTile = new Tile();
        curTile.transform.position = new Vector3(xPos, yPos);
        curTile.posX = xPos;
        curTile.posY = yPos;
        return curTile;
    }

    private void GridInit()
    {
        for (int h = 0; h < WorldHeight; h++)
        {
            WorldTiles[h] = new Tile[WorldWidth]; 
            for (int w = 0; w < WorldWidth; w++)
            {
                Tile curTile = InitTileAt(w, h);
                curTile.UpdateTileType(Tile.Type.grass);
                WorldTiles[h][w] = curTile;
            }
        }
    }
    #endregion



    // --------------- DEBUG -----------------
    #region DEBUG
    public void SetTileDebugText()
    {
    }

    #endregion


}
