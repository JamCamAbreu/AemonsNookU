using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Booth_Gems : Building
{
    public override BuildingInfo.Type Type { get { return BuildingInfo.Type.BOOTH_GEMS; } }
    public override string Name { get { return "Gems"; } }
    public override string Description { get { return "Glimmering gems, jewels, valuables attract wealthy peeps."; } }
    public override int Capacity { get { return 1; } }

}
