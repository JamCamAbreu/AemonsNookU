using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Tavern : Building
{
    public override BuildingInfo.Type Type { get { return BuildingInfo.Type.TAVERN; } }
    public override string Name { get { return "Tavern"; } }
    public override string Description { get { return "Drinks for everyone! Careful though, tipsy peeps might start a fight!"; } }
    public override int Capacity { get { return 8; } }
}
