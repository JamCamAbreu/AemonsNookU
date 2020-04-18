using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Booth_Fish : Building
{
    public override BuildingInfo.Type Type { get { return BuildingInfo.Type.BOOTH_FISH; } }
    public override string Name { get { return "Fish"; } }
    public override string Description { get { return "Fresh fish caught just this morning!"; } }
    public override int Capacity { get { return 2; } }
}
