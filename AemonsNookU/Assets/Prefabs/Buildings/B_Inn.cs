using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class B_Inn : Building
{
    public override BuildingInfo.Type Type { get { return BuildingInfo.Type.INN; } }
    public override string Name { get { return "Inn"; } }
    public override string Description { get { return "A bite to eat, a place to sleep. Oh, and some cool ale too!"; } }
    public override int Capacity { get { return 10; } }
}
