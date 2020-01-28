using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task 
{
    public TaskInfo.Type TaskType { get; set; }
    public Peep MyPeep { get; set; }

    // Returns true if more work to do, false if complete
    public abstract bool Step();
}
