using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Bath : Building
{

    public override BuildingInfo.Type Type { get { return BuildingInfo.Type.BATH; } }
    public override string Name { get { return "Public Bath"; } }
    public override string Description { get { return "Peeps can finally scrub off that dirt and grime!"; } }
    public override int Capacity { get { return 8; } }

}
