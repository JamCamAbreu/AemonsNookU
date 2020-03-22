using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float tilesTall;
    public float tilesWide;
    public const float offset = 0.0f;

    public BuildingInfo.Type Type;
    public string Name;
    public string Description;
    public BuildingSelection.Rotation Rotation;

    public List<CodeTile> TilesUnderneath = new List<CodeTile>();
    public List<CodeTile> Entrances = new List<CodeTile>();

    public Sprite normal;
    public Sprite clockOne;
    public Sprite clockTwo;
    public Sprite clockThree;

    public int originX;
    public int originY;

    public int Capacity;
    public List<Peep> Occupants = new List<Peep>();

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
