using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Scribe : Building
{
    public void Awake()
    {
        this.Type = BuildingInfo.Type.SCRIBE;
        this.Name = "Scribe";
        this.Description = "Sells parchment, quills, ink to those who can write. Also can write letters for the less educated peeps.";
        this.Capacity = 5;
    }


}
