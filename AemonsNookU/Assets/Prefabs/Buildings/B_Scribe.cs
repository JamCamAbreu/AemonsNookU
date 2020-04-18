using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Scribe : Building
{
    public override BuildingInfo.Type Type { get { return BuildingInfo.Type.SCRIBE; } }
    public override string Name { get { return "Scribe"; } }
    public override string Description { get { return "Sells parchment, quills, ink to those who can write. Also can write letters for the less educated peeps."; } }
    public override int Capacity { get { return 2; } }
}
