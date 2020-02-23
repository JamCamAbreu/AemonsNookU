using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Cloth : Building
{
    public void Awake()
    {
        this.Type = BuildingInfo.Type.CLOTH;
        this.Name = "Clothery";
        this.Description = "Warm garments and stylish gowns";
        this.Capacity = 4;
    }


}
