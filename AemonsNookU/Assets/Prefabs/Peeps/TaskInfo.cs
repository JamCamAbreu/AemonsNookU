using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TaskInfo
{

    public enum Type
    {
        WALK, 
        SEEK_FOOD, 
        SEEK_REST, 
        EXIT, 
        SEEK_BRAWL, 
        POOP, 
        SEEK_TAVERN, 
        SEEK_BATHROOM, 
        SEEK_BLACKSMITH
    }

    public static Task GenerateTask(Type t)
    {
        // todo
        Task task = new Task();
        return task;
    }


}
