using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03 : Level
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
TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT-----333-----TT
TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT----DDDDD------TT
TTTTTTTTT-----TTTTTTTTTTTT--------DDDD--------TTTT
TTTTT-------------TTTT----------DDD----------TTTTT
TT-TTT-------------------------DDD------TTTTTTTTTT
TTTTTTTTTT--------------------DDD-------TTTTTTTTTT
TTTTTTTT--------D------------DDD-----------TTTTTTT
TTTTTT----------D------------DD-------------------
TTTTT-----------D------------DD-------------------
----------------D-----------DD--------------------
----------------D---------DDD---------------------
--------------DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD-----
-----------DDDD-----------------------------------
----------DD--------------------------------------
--------DDD---------------------------------------
1DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD2
1DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD2
--------DDDDD-------------------------------------
------------DD------------------------------------
-------------DD-----------------------------------
-------------DD-----------------------------------
----DDDDDDDDDDD-----------------------------------
--------------DDD--DDDDDDDDDDDD-----------------TT
---------------DDDDD----------DDD--------------TTT
-------------DDDD---------------DDD----------TTTTT
------------DD--------------------D--------TTTTTTT
----------DDD---------TTTTTTT-----D------TTTTTTTTT
-------DDD----------TTTTTTTTT-----D---TTTTTTTTTTTT
W----DD-----------TTTT-----------DD----TTTTTTTTTTT
5DDDD-------------TTTTTTT------DD-------TTTT------
W---------------TTTTTTT-------DD-------TTTT-------
-TTTT---------TTTTTTT---------D--------TTT-------W
TTTTTWWWWWWWTTTTTTTTTT--------DD--------------DDD4
TTTTTTTTWWWWTWWTTTTTTTTTT------DDD--------DDDDD--W
TTTTTTTWWWWWWWWTTTTTTTTTTT--------DDDDDDDDD-------
TTTTTTTTWWTTTTTTTTTTTTTTTTTT----------------------";
        }
    }
}
