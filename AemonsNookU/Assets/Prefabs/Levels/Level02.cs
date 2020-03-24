using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02 : Level
{

    // Starting research, etc...

    public override int WIDTH {
        get { return 19; }
    }

    public override int HEIGHT {
        get { return 11; }
    }

    protected override string ascii 
    {
        get {
            return @"
TT-----------------
T------------T-----
----DDDDDD---------
--DDDWWWWDD----T---
1DDWWWWWWWDDD------
----WWWWW--DDDDDDD2
-------------------
-W--------------T--
----TTTTTTTTTTT----
-----TTTTTTTTTWW---
---TTTTTTTTTTTTTT--";
        }
    }
}
