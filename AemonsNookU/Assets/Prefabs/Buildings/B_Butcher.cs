using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Butcher : Building
{
    public override BuildingInfo.Type Type { get { return BuildingInfo.Type.BUTCHER; } }
    public override string Name { get { return "Butcher"; } }
    public override string Description { get { return "Fresh cuts, no hearty meal goes without a sale to the butcher!"; } }
    public override int Capacity { get { return 4; } }
}
