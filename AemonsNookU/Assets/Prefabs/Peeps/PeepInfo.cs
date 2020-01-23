using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PeepInfo
{
    public enum Type
    {
        homeless,
        thief,
        child,
        farmer,
        trader,
        monk,
        nun,
        foreigner,
        elder,
        priest,
        knight,
        witch,
        bard,
        quester,
        wizard,
        bishop,
        lady,
        king
    }

    public enum Sex
    {
        male,
        female
    }

    public static void UpdatePeepType(Peep p, Type t)
    {
        p.Type = t;
        p.Fame = GenerateFame(t);
        p.FirstName = GenerateFirstName(t);
        p.SirName = GenerateSirname(t);
    }


    public static string GenerateFirstName(Type t)
    {
        return "todo";
    }
    public static string GenerateSirname(Type t)
    {
        return "todo";
    }

    public static Sex GenerateSex(Type t)
    {
        // todo
        return Sex.female;
    }


    public static int GenerateFame(Type t)
    {
        switch (t)
        {
            case Type.homeless:
                return 1;
            case Type.thief:
                return 1;
            case Type.child:
                return 2;
            case Type.farmer:
                return 3;
            case Type.trader:
                return 5;
            case Type.monk:
                return 6;
            case Type.nun:
                return 6;
            case Type.foreigner:
                return 7;
            case Type.elder:
                return 7;
            case Type.priest:
                return 9;
            case Type.knight:
                return 12;
            case Type.witch:
                return 12;
            case Type.bard:
                return 13;
            case Type.quester:
                return 14;
            case Type.wizard:
                return 16;
            case Type.bishop:
                return 20;
            case Type.lady:
                return 25;
            case Type.king:
                return 30;
            default:
                return 0;
        }
    }

}
