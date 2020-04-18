using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Tanner : Building
{
    public override BuildingInfo.Type Type { get { return BuildingInfo.Type.TANNER; } }
    public override string Name { get { return "Tanner"; } }
    public override string Description { get { return "Tough hide is worked into leather for armor or tools."; } }
    public override int Capacity { get { return 2; } }
}
