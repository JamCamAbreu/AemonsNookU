using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Archery : Building
{
    public void Awake()
    {
        this.Type = BuildingInfo.Type.ARCHERY;
        this.Name = "Archery Range";
        this.Description = "Allow peeps to train their archery skills.";
        this.Capacity = 4;
    }


}
