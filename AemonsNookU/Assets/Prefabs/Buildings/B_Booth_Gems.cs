using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Booth_Gems : Building
{
    public void Awake()
    {
        this.Type = BuildingInfo.Type.BOOTH_GEMS;
        this.Name = "Gems Booth";
        this.Description = "Glimmering gems, jewels, valuables attract wealthy peeps.";
        this.Capacity = 4;
    }


}
