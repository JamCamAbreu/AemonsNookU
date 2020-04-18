using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Assertions;

public class C_Building : Card
{

    #region Retrieved from Card Generator
    public World world { get; set; }
    public BuildingSelection buildingSelectionPrefab { get; set; }
    public Building buildingPrefab { get; set; }
    public BuildingInfo.Type buildingType { get; set; }
    #endregion

    public override void PerformAction()
    {
        Assert.IsNotNull(world);
        Assert.IsNotNull(buildingSelectionPrefab);
        Assert.IsNotNull(buildingPrefab);

        BuildingSelection bSelection = Instantiate(buildingSelectionPrefab);
        bSelection.Init(world, buildingType, buildingPrefab);
    }
}
