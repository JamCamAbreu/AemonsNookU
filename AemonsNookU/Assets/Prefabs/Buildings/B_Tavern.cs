using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Tavern : Building
{
    public void Awake()
    {
        this.Type = BuildingInfo.Type.TAVERN;
        this.Name = "Tavern";
        this.Description = "Drinks for everyone! Careful though, tipsy peeps might start a fight!";
        this.Capacity = 9;
    }


}
