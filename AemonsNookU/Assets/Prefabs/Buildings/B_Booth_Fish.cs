using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Booth_Fish : Building
{
    public void Awake()
    {
        this.Type = BuildingInfo.Type.BOOTH_FISH;
        this.Name = "Fish Booth";
        this.Description = "Fresh fish caught just this morning!";
        this.Capacity = 4;
    }


}
