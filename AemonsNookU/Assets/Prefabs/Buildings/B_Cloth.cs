using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Cloth : Building
{
    public override BuildingInfo.Type Type { get { return BuildingInfo.Type.CLOTH; } }
    public override string Name { get { return "Clothery"; } }
    public override string Description { get { return "Warm garments and stylish gowns"; } }
    public override int Capacity { get { return 3; } }
}
