using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeepGenerator
{

    // This class will have an interface and be USED by the World class. 

    public int CreationAlarmReset;
    public int CreationAlarm;

    public PeepGenerator()
    {
        CreationAlarmReset = 60 * 5;
        CreationAlarm = CreationAlarmReset;
    }

    //public Peep GeneratePeep(Peep.Type type)
    //{


    //}

}
