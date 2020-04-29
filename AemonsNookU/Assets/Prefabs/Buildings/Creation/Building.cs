using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Building : MonoBehaviour
{
    public float tilesTall;
    public float tilesWide;
    public const float offset = 0.0f;

    //public virtual BuildingInfo.Type Type { get; }
    //public virtual string Name { get; }
    //public virtual string Description { get; }

    public virtual BuildingInfo.Type Type { get { return BuildingInfo.Type.ARCHERY; } set { Type = value; } }
    public virtual string Name { get { return "Error, not initialized properly!"; } set { } }
    public virtual string Description { get { return "Error, not initialized properly!"; } set { } }
    public virtual int Capacity { get { return 0; } set { Capacity = value; } }


    public BuildingSelection.Rotation Rotation;

    public List<CodeTile> TilesUnderneath = new List<CodeTile>();
    public List<CodeTile> Entrances = new List<CodeTile>();
    public SignPost sign;

    public Sprite Icon;

    public Sprite normal;
    public Sprite clockOne;
    public Sprite clockTwo;
    public Sprite clockThree;

    public int originX;
    public int originY;



    private List<Peep> Occupants = new List<Peep>();
    public void AddOccupant(Peep p)
    {
        Occupants.Add(p);
    }
    public void RemoveOccupant(Peep p)
    {
        Occupants.Remove(p);
    }
    public List<Peep> EmptyOccupants()
    {
        int numBefore = this.Occupants.Count;
        List<Peep> returnList = new List<Peep>(this.Occupants);

        this.Occupants.Clear();

        Assert.IsTrue(returnList.Count == numBefore, "Error in Building.cs - Check how duplicating C# lists work.");
        return returnList;
    }


    public SpriteRenderer MySpriteRend
    {
        get
        {
            return GetComponent<SpriteRenderer>();
        }
    }

    public void UpdateRotationSprite()
    {
        if (Rotation == BuildingSelection.Rotation.none) { MySpriteRend.sprite = normal; }
        else if (Rotation == BuildingSelection.Rotation.oneClock) { MySpriteRend.sprite = clockOne; }
        else if (Rotation == BuildingSelection.Rotation.twoClock) { MySpriteRend.sprite = clockTwo; }
        else if (Rotation == BuildingSelection.Rotation.threeClock) { MySpriteRend.sprite = clockThree; }
    }
    private void UpdatePosition()
    {
        if (Rotation == BuildingSelection.Rotation.none || Rotation == BuildingSelection.Rotation.twoClock)
        {
            this.transform.position = new Vector2(originX - offset, originY - offset);
        }
        else
        {
            this.transform.position = new Vector2(originX - offset, originY - offset);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }
}
