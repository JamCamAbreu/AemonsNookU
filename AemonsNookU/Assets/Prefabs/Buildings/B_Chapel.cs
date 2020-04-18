using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Chapel : Building
{
    public override BuildingInfo.Type Type { get { return BuildingInfo.Type.CHAPEL; } }
    public override string Name { get { return "Chapel"; } }
    public override string Description { get { return "Peeps of all walks of life seek wisdom and truth."; } }
    public override int Capacity { get { return 10; } }
}
