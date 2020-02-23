using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Inn : Building
{
    public void Awake()
    {
        this.Type = BuildingInfo.Type.INN;
        this.Name = "Inn";
        this.Description = "A bite to eat, a place to sleep.";
        this.Capacity = 10;
    }


}
