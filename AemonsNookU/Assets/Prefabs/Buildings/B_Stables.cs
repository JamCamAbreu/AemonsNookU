using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Stables : Building
{
    public override BuildingInfo.Type Type { get { return BuildingInfo.Type.STABLES; } }
    public override string Name { get { return "Stables"; } }
    public override string Description { get { return "Mounted peeps can leave their horses here for care. Wealthy peeps may purchase horses here."; } }
    public override int Capacity { get { return 4; } }
}
