﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01 : Level
{

    // Starting research, etc...

    public override int WIDTH {
        get { return 50; }
    }

    public override int HEIGHT {
        get { return 35; }
    }

    protected override string ascii 
    {
        get {
            return @"
TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT
TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT
TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT-T-T-TTT-TTTTTTTTTT
TTTTTTTT-TTTTTTSSTTTTTTTTTTTTTTTTTTTTTT-TTTTTTTTTT
TT-TTTTTTTT--SSSS----------TTTTTT-----TTTTTTTTTTTT
TTTTTTTTTT--SSSS------------------SS--TTTTTTTTTTTT
TTTTTTTT--SSSSS----DDDDDDDDDDD-------------TTTTTTT
TTTTTTTT--------DDDDDDDDDDDDDDDDDDDDDDSSSSSSS--TT-
TTTTTT-T------DDDDD--------DDDDDDDDDDDDDD---------
TTTTTTTT-----DDD-----T---------------DDDDDDD------
TTTTTT-----DDDD----TTTTT----------------DDDDDDD---
----------DDDD----TT-T-T-----TTT-TTSSS------DDDDD2
-SS----DDDDD-----TTTTT-T------TTTTTTT-SS-----DDDD2
-----DDDDD-------TTTTT-T--------TTTTTTT-----DDDDD2
----DDDDDDDD----TTTTTT-TT--DDDD---TTTTT----DD-S-SS
-DDDDD-----DD--T-TTTTT-TT-----DD---TTS----DD------
1DDD---SS---DD-T-TTTTTT-TT-----DD-------DDD----SS-
1DD---SSSS---DDTTTTTTT-TTTT-----DD----DDD---S--SSS
SS-----SS-T-TTDDTTTTTTTT---------DD-DDD----SSS--SS
SSSS----T-TTTTTDTT--T--T-SSSSS---DDDD---SS------TS
-S-----TTTTT-T-DDTTTTTTTTT-------DD----S------TTTT
----TTTT-TTTTTTTD-----TTTTTT-----DD---------TTTTTT
---TTTTTTTTTTTT-D--------TTT--DDDDDD-------TTTTTTT
-------TTTTT----DDDDDDD------DD----DDD--TTTTTTTTTT
-S-SS---TTTS---DD-----DDDDDDDD----TTDDDTTTTTTTTTTT
-------TTTSS--DD---T------------TTTTTTDDDTTTTTTT-T
4DD--S-TTTSS-DD---TT--TTTTTTTTTTTTT-T-TDDDTTTTTTTT
--DDD---TT---D----TTTTTTTTTTT-TT--T-TTTTTDDDTT-TTT
----DDDDD----D--TTTTTTT-TTTWWTTTT-TTTTTT-TTDDTTT--
--------DDDDDD--TTTT-TTTTWWWWWW-T-TTTTTTTTTDDD----
--TTTT--SS------TTTTTTTWWWWT-TTTTTT--T--TT--DD----
-TTTT--SSSS---TTTTTTTTWWT-TTTTT-TTTTTTTTT---DD----
TTTT-WWWWWWWTTT-TT-TTT-T-TT-TTTTT-----------DD----
TTT-TTTTWWWWTWWTTTTT--TTTTTTTT------------DDDD----
TTTTTTTWWWWWWWWTTTTTTTTT-TTT--------------DD------
TTTTTTTTWWTTTTTTTTTTTTTTTTT---------------333-----";
        }
    }
}
