using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMenuButton : MonoBehaviour
{

    public World world;

    public BuildingInfo.Type bType;
    public BuildingSelection selectionPrefab;

    public Building buildingPrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Click()
    {
        CreateSelection();
    }

    public void CreateSelection()
    {
        BuildingSelection buildingSelection = Object.Instantiate(selectionPrefab);
        buildingSelection.Init(world, bType, buildingPrefab);
    }

}
