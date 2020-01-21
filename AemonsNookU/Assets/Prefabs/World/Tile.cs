using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
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

    public Tile TileAbove { get; set; }
    public Tile TileRight { get; set; }
    public Tile TileBelow { get; set; }
    public Tile TileLeft { get; set; }

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

    }



}
