using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Bath : Building
{
    public void Awake()
    {
        this.Type = BuildingInfo.Type.BATH;
        this.Name = "Public Bath";
        this.Description = "Peeps can finally scrub that dirt off!";
        this.Capacity = 8;
    }


}
