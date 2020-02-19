using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelection : MonoBehaviour
{
    public World world { get; set; }

    public BuildingSelectionSquare SquarePrefab;
    public List<BuildingSelectionSquare> mySquares = new List<BuildingSelectionSquare>();

    public int originX;
    public int originY;

    public int lastValidMouseX = 0;
    public int lastValidMouseY = 0;

    const float spriteOffset = 0.5f;

    public CodeTile TileUnderMouse;

    public bool isPlaceable;

    // Update is called once per frame
    public void Update()
    {
        FollowMouse();
        isPlaceable = AnalyzeAndUpdatePlacementSquares();
    }

    

    public void Init(World worldScript, BuildingInfo.Type buildingType)
    {
        world = worldScript;
        List<Tuple<int, int>> relativeCoordinates = BuildingInfo.RetrieveRelativeCoordinates(buildingType);
        List<Tuple<int, int>> requiredRoadPositions = BuildingInfo.RetrieveRequiredRoadPositions(buildingType);

        foreach (Tuple<int, int> coord in relativeCoordinates)
        {
            BuildingSelectionSquare square = UnityEngine.Object.Instantiate(SquarePrefab);
            square.transform.position = new Vector2(originX + coord.Item1 + spriteOffset, originY + coord.Item2 + spriteOffset);
            square.relativeX = coord.Item1;
            square.relativeY = coord.Item2;
            square.myType = BuildingSelectionSquare.Type.building;
            mySquares.Add(square);
        }

        foreach (Tuple<int, int> coord in requiredRoadPositions)
        {
            BuildingSelectionSquare square = UnityEngine.Object.Instantiate(SquarePrefab);
            square.transform.position = new Vector2(originX + coord.Item1 + spriteOffset, originY + coord.Item2 + spriteOffset);
            square.relativeX = coord.Item1;
            square.relativeY = coord.Item2;
            square.myType = BuildingSelectionSquare.Type.entrance;
            mySquares.Add(square);
        }
    }

    public void FollowMouse()
    {
        Vector2 point = world.cameraPrefab.ScreenToWorldPoint(Input.mousePosition);
        int worldX = (int)point.x;
        int worldY = (int)point.y;

        if (worldX >= 0 && worldX <= world.WorldWidth)
        {
            lastValidMouseX = worldX;
        }

        if (worldY >= 0 && worldY <= world.WorldHeight)
        {
            lastValidMouseY = worldY;
        }

        TileUnderMouse = world.TileAt(lastValidMouseX, lastValidMouseY);

        this.originX = lastValidMouseX;
        this.originY = lastValidMouseY;
    }

    public bool AnalyzeAndUpdatePlacementSquares()
    {
        bool placementOkay = true;

        CodeTile curTile;
        foreach (BuildingSelectionSquare square in mySquares)
        {
            square.transform.position = new Vector2(originX + square.relativeX + spriteOffset, originY + square.relativeY + spriteOffset);

            curTile = world.TileAt(originX + square.relativeX, originY + square.relativeY);
            if (curTile != null)
            {
                square.TileUnderneath = curTile;
                if (square.UpdatePlaceable() == false)
                {
                    placementOkay = false;
                }
            }
            else
            {
                // set invisible
            }
        }

        return placementOkay;
    }

}
