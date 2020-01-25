using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public abstract class Level
{

    // abstract things
    public abstract int WIDTH { get; }
    public abstract int HEIGHT { get; }
    protected abstract string ascii { get; }

    public string GetLevelCode()
    {
        return Regex.Replace(ascii, @"\s+", "");
    }
}
