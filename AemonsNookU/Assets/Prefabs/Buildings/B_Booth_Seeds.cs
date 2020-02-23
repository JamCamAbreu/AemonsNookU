using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Booth_Seeds : Building
{
    public void Awake()
    {
        this.Type = BuildingInfo.Type.BOOTH_SEEDS;
        this.Name = "Seeds Booth";
        this.Description = "Sellings seeds allows peeps to grow their own gardens.";
        this.Capacity = 4;
    }


}
