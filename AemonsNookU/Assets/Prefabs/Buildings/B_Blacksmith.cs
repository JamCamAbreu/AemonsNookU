using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Blacksmith : Building
{
    public override BuildingInfo.Type Type { get { return BuildingInfo.Type.ARCHERY; } }
    public override string Name { get { return "Blacksmith"; } }
    public override string Description { get { return "Hard working Blacksmith peeps craft tools and weapons to sell."; } }
    public override int Capacity { get { return 8; } }

}
