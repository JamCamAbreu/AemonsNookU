using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuildingInfo
{
    public enum Type
    {
        ARCHERY, 
        BLACKSMITH, 
        TAVERN, 
        BOOTH_PRODUCE, 
        BOOTH_FISH, 
        BOOTH_GEMS, 
        BOOTH_SEEDS, 
        BUTCHER, 
        STABLES, 
        TANNER, 
        SCRIBE, 
        CHAPEL, 
        INN, 
        BATH, 
        CLOTH, 
        ROAD
    }


    public static List<Tuple<int, int>> RotateCoordinatesOnce(List<Tuple<int, int>> input)
    {
        List<Tuple<int, int>> output = new List<Tuple<int, int>>();

        foreach (Tuple<int, int> tup in input)
        {
            // todo
        }

        return output;
    }


    public static List<Tuple<int, int>> RetrieveRequiredRoadPositions(Type t)
    {
        List<Tuple<int, int>> relativeCoordinates = new List<Tuple<int, int>>();

        switch (t)
        {
            case Type.ARCHERY:
                //      +++
                //      +++
                //        ^
                relativeCoordinates.Add(Tuple.Create(2, -1));
                break;

            case Type.BLACKSMITH:
                //      ++
                //      ++
                //       ^
                relativeCoordinates.Add(Tuple.Create(1, -1));
                break;

            case Type.BOOTH_PRODUCE:
                //      ++
                //      ^^
                relativeCoordinates.Add(Tuple.Create(0, -1));
                relativeCoordinates.Add(Tuple.Create(1, -1));
                break;

            case Type.BOOTH_FISH:
                //      ++
                //      ^^
                relativeCoordinates.Add(Tuple.Create(0, -1));
                relativeCoordinates.Add(Tuple.Create(1, -1));
                break;

            case Type.BOOTH_GEMS:
                //      +
                //      ^ 
                relativeCoordinates.Add(Tuple.Create(0, -1));
                break;

            case Type.BOOTH_SEEDS:
                //      +
                //      ^ 
                relativeCoordinates.Add(Tuple.Create(0, -1));
                break;

            case Type.BUTCHER:
                //      ++
                //      ++
                //      ^
                relativeCoordinates.Add(Tuple.Create(0, -1));
                break;

            case Type.CHAPEL:
                //      +++
                //      +++
                //       ^
                relativeCoordinates.Add(Tuple.Create(1, -1));
                break;

            case Type.CLOTH:
                //      ++
                //      ++
                //      ^
                relativeCoordinates.Add(Tuple.Create(0, -1));
                break;

            case Type.INN:
                //      +++
                //      +++
                //       ^
                relativeCoordinates.Add(Tuple.Create(1, -1));
                break;

            case Type.ROAD:
                break;

            case Type.SCRIBE:
                //      ++
                //      ++
                //       ^
                relativeCoordinates.Add(Tuple.Create(1, -1));
                break;

            case Type.STABLES:
                //      +++
                //      +++
                //      ^
                relativeCoordinates.Add(Tuple.Create(0, -1));
                break;

            case Type.TANNER:
                //      ++
                //      ++
                //      ^
                relativeCoordinates.Add(Tuple.Create(0, -1));
                break;

            case Type.TAVERN:
                //      ++
                //      ++
                //      ^
                relativeCoordinates.Add(Tuple.Create(1, -1));
                break;

            case Type.BATH:
                //      +++
                //      +++
                //      +++
                //       ^
                relativeCoordinates.Add(Tuple.Create(1, -1));
                break;

            default:
                break;
        }

        return relativeCoordinates;
    }


    public static List<Tuple<int, int>> RetrieveRelativeCoordinates(Type t)
    {
        List<Tuple<int, int>> relativeCoordinates = new List<Tuple<int, int>>();
        relativeCoordinates.Add(Tuple.Create(0, 0)); // (x, y)

        switch (t)
        {
            case Type.ARCHERY:
                relativeCoordinates.Add(Tuple.Create(0, 1));

                relativeCoordinates.Add(Tuple.Create(1, 0));
                relativeCoordinates.Add(Tuple.Create(1, 1));

                relativeCoordinates.Add(Tuple.Create(2, 0));
                relativeCoordinates.Add(Tuple.Create(2, 1));
                break;

            case Type.BLACKSMITH:
                relativeCoordinates.Add(Tuple.Create(0, 1));

                relativeCoordinates.Add(Tuple.Create(1, 0));
                relativeCoordinates.Add(Tuple.Create(1, 1));
                break;

            case Type.BOOTH_PRODUCE:
                relativeCoordinates.Add(Tuple.Create(1, 0));
                break;

            case Type.BOOTH_FISH:
                relativeCoordinates.Add(Tuple.Create(1, 0));
                break;

            case Type.BOOTH_GEMS:
                break;

            case Type.BOOTH_SEEDS:
                break;

            case Type.BUTCHER:
                relativeCoordinates.Add(Tuple.Create(0, 1));

                relativeCoordinates.Add(Tuple.Create(1, 0));
                relativeCoordinates.Add(Tuple.Create(1, 1));
                break;

            case Type.CHAPEL:
                relativeCoordinates.Add(Tuple.Create(0, 1));

                relativeCoordinates.Add(Tuple.Create(1, 0));
                relativeCoordinates.Add(Tuple.Create(1, 1));

                relativeCoordinates.Add(Tuple.Create(2, 0));
                relativeCoordinates.Add(Tuple.Create(2, 1));
                break;

            case Type.CLOTH:
                relativeCoordinates.Add(Tuple.Create(0, 1));

                relativeCoordinates.Add(Tuple.Create(1, 0));
                relativeCoordinates.Add(Tuple.Create(1, 1));


                break;

            case Type.INN:
                relativeCoordinates.Add(Tuple.Create(0, 1));

                relativeCoordinates.Add(Tuple.Create(1, 0));
                relativeCoordinates.Add(Tuple.Create(1, 1));

                relativeCoordinates.Add(Tuple.Create(2, 0));
                relativeCoordinates.Add(Tuple.Create(2, 1));
                break;

            case Type.ROAD:
                break;

            case Type.SCRIBE:
                relativeCoordinates.Add(Tuple.Create(0, 1));

                relativeCoordinates.Add(Tuple.Create(1, 0));
                relativeCoordinates.Add(Tuple.Create(1, 1));
                break;

            case Type.STABLES:
                relativeCoordinates.Add(Tuple.Create(0, 1));

                relativeCoordinates.Add(Tuple.Create(1, 0));
                relativeCoordinates.Add(Tuple.Create(1, 1));

                relativeCoordinates.Add(Tuple.Create(2, 0));
                relativeCoordinates.Add(Tuple.Create(2, 1));
                break;

            case Type.TANNER:
                relativeCoordinates.Add(Tuple.Create(0, 1));

                relativeCoordinates.Add(Tuple.Create(1, 0));
                relativeCoordinates.Add(Tuple.Create(1, 1));
                break;

            case Type.TAVERN:
                relativeCoordinates.Add(Tuple.Create(0, 1));

                relativeCoordinates.Add(Tuple.Create(1, 0));
                relativeCoordinates.Add(Tuple.Create(1, 1));
                break;

            case Type.BATH:
                relativeCoordinates.Add(Tuple.Create(0, 1));
                relativeCoordinates.Add(Tuple.Create(0, 2));

                relativeCoordinates.Add(Tuple.Create(1, 0));
                relativeCoordinates.Add(Tuple.Create(1, 1));
                relativeCoordinates.Add(Tuple.Create(1, 2));

                relativeCoordinates.Add(Tuple.Create(2, 0));
                relativeCoordinates.Add(Tuple.Create(2, 1));
                relativeCoordinates.Add(Tuple.Create(2, 2));
                break;

            default:
                break;
        }

        return relativeCoordinates;
    }





}
