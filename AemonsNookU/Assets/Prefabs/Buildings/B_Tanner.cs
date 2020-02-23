using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Tanner : Building
{
    public void Awake()
    {
        this.Type = BuildingInfo.Type.TANNER;
        this.Name = "Tanner";
        this.Description = "Tough hide is worked into leather for armor or tools.";
        this.Capacity = 4;
    }


}
