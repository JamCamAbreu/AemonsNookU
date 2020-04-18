using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class B_Archery : Building
{

    public override BuildingInfo.Type Type { get { return BuildingInfo.Type.ARCHERY; } }
    public override string Name { get { return "Archery"; } }
    public override string Description { get { return "Allow peeps to train their archery skills."; } }
    public override int Capacity { get { return 4; } }

}
