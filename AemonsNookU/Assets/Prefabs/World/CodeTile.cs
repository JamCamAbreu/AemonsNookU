using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeTile 
{

    // Remember: A Tile is not a prefab. It's just a C# class,
    // that has data and methods. The World class will be responsible
    // for drawing the tiles using the tilemap system in unity.

    public enum Type 
    {
        grass,
        road,
        water,
    }

    /// Properties
    public int posX { get; set; }
    public int posY { get; set; }
    public bool isBuilding { get; set; }
    public bool isPath { get; set; }

    public CodeTile TileAbove { get; set; }
    public CodeTile TileRight { get; set; }
    public CodeTile TileBelow { get; set; }
    public CodeTile TileLeft { get; set; }

    private Type _type { get; set; }
    public Type TileType { get { return _type; } set { _type = value; } }

    private void Awake()
    {
        isBuilding = false;
        isPath = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTileType(Type t)
    {
        TileType = t;
    }



}
