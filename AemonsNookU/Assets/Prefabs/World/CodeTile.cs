﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeTile 
{

    // Remember: A Tile is not a prefab. It's just a C# class,
    // that has data and methods. The World class will be responsible
    // for drawing the tiles using the tilemap system in unity.

    public World world;

    public enum Type 
    {
        grass,
        road,
        water,
        tree,
        stone,
        building
    }

    /// Properties
    public int posX { get; set; }
    public int posY { get; set; }
    public bool canBuild { get; set; }
    public bool isBuilding { get; set; }
    public bool isPath { get; set; }

    // Edge:
    public bool isMapEdge { get; set; }
    public int mapEdgeId { get; set; }

    public CodeTile TileAbove { get; set; }
    public CodeTile TileRight { get; set; }
    public CodeTile TileBelow { get; set; }
    public CodeTile TileLeft { get; set; }
    public List<Clickable> Resources = new List<Clickable>();

    public Building ParentBuilding { get; set; }

    private Type _type { get; set; }
    public Type TileType { get { return _type; } set { _type = value; } }

    public CodeTile()
    {
        isBuilding = false;
        isPath = false;
        isMapEdge = false;
        mapEdgeId = -1;

        ParentBuilding = null;
    }

    public void UpdateTileType(Type t)
    {
        TileType = t;
        canBuild = isBuildableType(t);
    }

    public bool isBuildableType(Type t)
    {
        switch (t)
        {
            case Type.building:
                return false;

            case Type.grass:
                return true;

            case Type.road:
                return false;

            case Type.stone:
                return false;

            case Type.tree:
                return false;

            case Type.water:
                return false;
        }

        throw new System.Exception($"Invalid buildable type. CodeTile.cs, isBuildableType method");
    }


}
