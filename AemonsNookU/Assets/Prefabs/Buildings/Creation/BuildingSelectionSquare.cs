using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelectionSquare : MonoBehaviour
{
    public enum Type
    {
        building,
        entrance
    }
    public enum SpriteType
    {
        buildingPlacementGood,
        buildingPlacementBad,
        buildingEntranceMissingRoad,
        buildingEntranceConnectedRoad
    }

    public Sprite BuildingPlacementGood;
    public Sprite BuildingPlacementBad;
    public Sprite BuildingEntranceMissingRoad;
    public Sprite BuildingEntranceConnectedRoad;

    public CodeTile TileUnderneath;
    public Type myType;

    public int relativeX;
    public int relativeY;

    public void Update()
    {
    }

    public void ForceSprite(bool canBuild)
    {
        if (myType == Type.building)
        {
            if (canBuild) { UpdateSprite(SpriteType.buildingPlacementGood); }
            else { UpdateSprite(SpriteType.buildingPlacementBad); }
        }
        else
        {
            if (canBuild) { UpdateSprite(SpriteType.buildingEntranceConnectedRoad); }
            else { UpdateSprite(SpriteType.buildingEntranceMissingRoad); }
        }
    }

    public bool LastPlaceable()
    {
        if (TileUnderneath != null)
        {
            if (myType == Type.building)
            {
                if (TileUnderneath.canBuild)
                {
                    UpdateSprite(SpriteType.buildingPlacementGood);
                    return true;
                }
                else
                {
                    UpdateSprite(SpriteType.buildingPlacementBad);
                    return false;
                }
            }
            else
            {
                if (TileUnderneath.isPath)
                {
                    UpdateSprite(SpriteType.buildingEntranceConnectedRoad);
                    return true;
                }
                else
                {
                    UpdateSprite(SpriteType.buildingEntranceMissingRoad);
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }


    public void UpdateSprite(SpriteType t)
    {
        switch (t)
        {
            case SpriteType.buildingPlacementGood:
                GetComponent<SpriteRenderer>().sprite = BuildingPlacementGood;
                break;

            case SpriteType.buildingPlacementBad:
                GetComponent<SpriteRenderer>().sprite = BuildingPlacementBad;
                break;

            case SpriteType.buildingEntranceConnectedRoad:
                GetComponent<SpriteRenderer>().sprite = BuildingEntranceConnectedRoad;
                break;

            case SpriteType.buildingEntranceMissingRoad:
                GetComponent<SpriteRenderer>().sprite = BuildingEntranceMissingRoad;
                break;

            default:
                break;
        }
    }
}
