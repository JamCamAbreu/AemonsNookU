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

    public Building myBuildingPrefab;

    public int originX;
    public int originY;
    const float spriteOffset = 0.5f;

    public int lastValidMouseX = 0;
    public int lastValidMouseY = 0;


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
            foreach (BuildingSelectionSquare square in mySquares)
            {
                GlobalMethods.Rot90(square);

                // Shuffle through rotations:
                myRotation++;
                if (myRotation > Rotation.threeClock) { myRotation = Rotation.none; }
            }
        }
    }
    

    public void Init(World worldScript, BuildingInfo.Type bType, Building prefab)
    {
        world = worldScript;
        myRotation = Rotation.none;
        myBuildingPrefab = prefab;

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
        Debug.Log($"Let's build the building: {buildingType}!");

        // Construct prefab
        Building createdBuilding = Instantiate(myBuildingPrefab);
        createdBuilding.Rotation = myRotation;
        createdBuilding.UpdateRotationSprite();

        this.world.AddBuilding(createdBuilding);

        foreach (BuildingSelectionSquare square in mySquares)
        {
            CodeTile curTile = square.TileUnderneath;

            // Both:
            curTile.ParentBuilding = createdBuilding;


            // Buildings:
            if (square.myType == BuildingSelectionSquare.Type.building)
            {
                curTile.UpdateTileType(CodeTile.Type.building);
                createdBuilding.TilesUnderneath.Add(curTile);
            }

            // Entrances:
            else
            {
                createdBuilding.Entrances.Add(curTile);

                if (createdBuilding.sign == null)
                {
                    SignPost sign = CreateSignPost(square.TileUnderneath.posX, square.TileUnderneath.posY, myRotation);
                    createdBuilding.sign = sign;
                    //sign.transform.SetParent(createdBuilding.transform);
                }
            }
        }
        this.world.TileMapUpdate();

        // Modify prefab:
        BuildingSelectionSquare bottomLeft = GetBottomLeftSquare();
        createdBuilding.originX = this.originX + bottomLeft.relativeX;
        createdBuilding.originY = this.originY + bottomLeft.relativeY;

        // Play sound effect

        // Notification:
        world.notificationCanvas.AddNotification(Notification.Type.userAction, $"Successfully constructed {createdBuilding.Name}.");
    }

    public SignPost CreateSignPost(int tileX, int tileY, Rotation rot)
    {
        SignPost prefab = this.world.decorationGenerator.signPostPrefab;
        SignPost sign = Instantiate(prefab);
        float adjustAmount = 0.25f;
        float baseX = tileX + 0.5f;
        float baseY = tileY + 0.5f;
        switch (rot)
        {
            case Rotation.none:
                sign.SetFacingDirection(SignPost.Facing.up);
                sign.SetPosition(new Vector2(baseX, baseY + adjustAmount));
                break;
            case Rotation.oneClock:
                sign.SetFacingDirection(SignPost.Facing.left);
                sign.SetPosition(new Vector2(baseX - adjustAmount, baseY));
                break;
            case Rotation.twoClock:
                sign.SetFacingDirection(SignPost.Facing.down);
                sign.SetPosition(new Vector2(baseX, baseY - adjustAmount));
                break;
            case Rotation.threeClock:
                sign.SetFacingDirection(SignPost.Facing.right);
                sign.SetPosition(new Vector2(baseX + adjustAmount, baseY));
                break;
            default:
                sign.SetFacingDirection(SignPost.Facing.up);
                sign.SetPosition(new Vector2(baseX, baseY));
                break;
        }

        return sign;
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

    public BuildingSelectionSquare GetBottomLeftSquare()
    {
        BuildingSelectionSquare retSquare = null;
        int smallestX = 0;
        int smallestY = 0;

        foreach (BuildingSelectionSquare square in mySquares)
        {
            if (square.myType == BuildingSelectionSquare.Type.building)
            {
                if (square.relativeX <= smallestX && square.relativeY <= smallestY)
                {
                    retSquare = square;
                }
            }
        }
        return retSquare;
    }

}
