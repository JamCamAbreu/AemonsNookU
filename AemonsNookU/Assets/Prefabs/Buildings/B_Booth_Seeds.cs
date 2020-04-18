using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Booth_Seeds : Building
{
    public override BuildingInfo.Type Type { get { return BuildingInfo.Type.BOOTH_SEEDS; } }
    public override string Name { get { return "Seeds"; } }
    public override string Description { get { return "Sellings seeds allows peeps to grow their own gardens."; } }
    public override int Capacity { get { return 4; } }

}
