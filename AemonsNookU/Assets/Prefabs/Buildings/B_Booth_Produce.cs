using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Booth_Produce : Building
{
    public override BuildingInfo.Type Type { get { return BuildingInfo.Type.BOOTH_PRODUCE; } }
    public override string Name { get { return "Produce"; } }
    public override string Description { get { return "Hearty vegetables grown by your most humble peep farmers."; } }
    public override int Capacity { get { return 3; } }
}
