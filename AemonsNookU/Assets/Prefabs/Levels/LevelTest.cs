using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTest : Level
{
    // Starting research, etc...
    public override int WIDTH {
        get { return 6; }
    }

    public override int HEIGHT {
        get { return 6; }
    }

    protected override string ascii 
    {
        get {
            return @"
W----W
D----D
W----W
D----D
W----W
D----D
";
        }

    }

}
