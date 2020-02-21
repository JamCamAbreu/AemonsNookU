using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelection : MonoBehaviour
{

    public enum Rotation
    {
        none,
        oneClock,
        twoClock,
        threeClock
    }

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

    public BuildingInfo.Type buildingType { get; set; }
    public Rotation myRotation { get; set; }

    // Update is called once per frame
    public void Update()
    {
        FollowMouse();
        isPlaceable = AnalyzeAndUpdatePlacementSquares();
        CheckCancel();
        CheckRotation();
        CheckPlacement();
    }

    public void CheckCancel()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            DestroyMe();
        }
    }

    public void CheckRotation()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

        }
    }
    

    public void Init(World worldScript, BuildingInfo.Type bType)
    {
        world = worldScript;
        myRotation = Rotation.none;

        List<Tuple<int, int>> relativeCoordinates = BuildingInfo.RetrieveRelativeCoordinates(bType);
        List<Tuple<int, int>> requiredRoadPositions = BuildingInfo.RetrieveRequiredRoadPositions(bType);

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

        this.buildingType = bType;
    }

    public void Build()
    {
        //TODO
        Debug.Log($"Let's build the building: {buildingType}!");
        BuildingConstructor.Construct(this.originX, this.originY, mySquares, buildingType, myRotation);
    }

    public void DestroyMe()
    {
        foreach (BuildingSelectionSquare square in mySquares)
        {
            Destroy(square.gameObject);
        }
        Destroy(this.gameObject);
    }

    public void CheckPlacement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                Build();
                DestroyMe();
            }
            else
            {
                Debug.Log($"Sorry, you cannot build here!");
            }
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
                if (square.LastPlaceable() == false)
                {
                    placementOkay = false;
                }
            }
            else
            {
                square.ForceSprite(false);
                placementOkay = false;
            }
        }

        return placementOkay;
    }

}
