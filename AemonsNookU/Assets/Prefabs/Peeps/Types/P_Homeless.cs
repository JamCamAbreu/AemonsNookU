using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class P_Homeless : Peep
{

    public override float RetrieveBuildingDurationMultiplier(BuildingInfo.Type type)
    {
        switch (type)
        {

            case BuildingInfo.Type.TAVERN:
                return 5.4f;

            case BuildingInfo.Type.BOOTH_PRODUCE:
                return 3.0f;

            case BuildingInfo.Type.BOOTH_GEMS:
                return 10.0f;

            case BuildingInfo.Type.BOOTH_FISH:
                return 3.0f;

            default:
                return 2.4f;
        }
    }

    public override void Start()
    {
        base.Start();
    }


    public override void Update()
    {
        base.Update();
    }

}
