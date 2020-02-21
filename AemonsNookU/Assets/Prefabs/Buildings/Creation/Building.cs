using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingInfo.Type Type;

    public List<CodeTile> TilesUnderneath;
    public List<CodeTile> InteractionTiles;

    public int originX;
    public int originY;
    public List<Tuple<int, int>> RelativeCoordinates;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
