using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Stables : Building
{
    public void Awake()
    {
        this.Type = BuildingInfo.Type.STABLES;
        this.Name = "Stables";
        this.Description = "Mounted peeps can leave their horses here for care. Wealthy peeps may purchase horses here.";
        this.Capacity = 8;
    }


}
