using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Blacksmith : Building
{
    public void Awake()
    {
        this.Type = BuildingInfo.Type.BLACKSMITH;
        this.Name = "Blacksmith";
        this.Description = "Hard working Blacksmith peeps craft tools and weapons to sell.";
        this.Capacity = 8;
    }


}
