using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMenuButton : MonoBehaviour
{

    public World world;
    public BuildingSelection buildingSelectionPrefab;

    public BuildingInfo.Type bType;

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
        BuildingSelection buildingSelection = Object.Instantiate(buildingSelectionPrefab);
        buildingSelection.Init(world, bType);
    }

}
