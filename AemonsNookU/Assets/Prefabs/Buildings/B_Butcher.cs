using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Butcher : Building
{
    public void Awake()
    {
        this.Type = BuildingInfo.Type.BUTCHER;
        this.Name = "Butcher";
        this.Description = "Fresh cuts, no hearty meal goes without a sale to the butcher!";
        this.Capacity = 4;
    }


}
