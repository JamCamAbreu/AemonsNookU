using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResearchInfo
{
    public enum Type
    {
        BUILD_ARCHERY, 
        BUILD_BLACKSMITH, 
        BUILD_TAVERN, 
        BUILD_BOOTH_PRODUCE, 
        BUILD_BOOTH_FISH, 
        BUILD_BOOTH_GEMS, 
        BUILD_BUTCHER, 
        BUILD_STABLES, 
        BUILD_TANNER, 
        BUILD_SCRIBE, 
        BUILD_CHAPEL, 
        BUILD_INN, 
        BUILD_BOOTH_SEEDS, 
        BUILD_BATH, 
        BUILD_CLOTH
    }

    public static string GetName(Type t)
    {
        return "todo";
    }

    public static string GetDescription(Type t)
    {
        return "todo";
    }

    public static List<Type> GetPrerequisits(Type t)
    {
        // todo
        List<Type> preR = new List<Type>();
        return preR;
    }


}
