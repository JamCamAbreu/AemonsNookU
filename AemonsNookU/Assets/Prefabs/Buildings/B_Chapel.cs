using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Chapel : Building
{
    public void Awake()
    {
        this.Type = BuildingInfo.Type.CHAPEL;
        this.Name = "Chapel";
        this.Description = "Peeps of all walks of life seek wisdom and truth.";
        this.Capacity = 14;
    }


}
