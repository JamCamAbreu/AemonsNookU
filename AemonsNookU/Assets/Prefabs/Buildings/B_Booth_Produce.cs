using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Booth_Produce : Building
{
    public void Awake()
    {
        this.Type = BuildingInfo.Type.BOOTH_PRODUCE;
        this.Name = "Produce Booth";
        this.Description = "Hearty vegetables grown by your most humble peep farmers.";
        this.Capacity = 4;
    }


}
