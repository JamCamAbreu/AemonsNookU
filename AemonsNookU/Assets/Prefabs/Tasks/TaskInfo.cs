using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public static class TaskInfo
{

    public enum Type
    {
        WALK_RANDOM,
        SEEK_FOOD,
        SEEK_REST,
        EXIT,
        SEEK_BRAWL,
        POOP,
        SEEK_TAVERN,
        SEEK_BATHROOM,
        SEEK_BLACKSMITH
    }


    // Revisit this after implementing the tile.Above, tile.Left, etc...

    public static Stack<CodeTile> GenerateWalkQueue(CodeTile startTile, CodeTile targetTile, List<CodeTile> allRoadTiles)
    {

        Assert.IsTrue(allRoadTiles.Contains(startTile));
        Assert.IsTrue(allRoadTiles.Contains(targetTile));

        Queue<CodeTile> tileQueue = new Queue<CodeTile>(); // paths to test
        Stack<CodeTile> returnQueue = new Stack<CodeTile>(); // our final path
        Dictionary<CodeTile, CodeTile> visitedTiles = new Dictionary<CodeTile, CodeTile>(); // tells us 1. where we visited, and 2. where from
        visitedTiles[startTile] = null; // our starting tile has no "from"

        tileQueue.Enqueue(startTile);
        CodeTile cur;
        while (tileQueue.Count > 0)
        {
            cur = tileQueue.Dequeue();

            // Target has been found:
            if (cur == targetTile)
            {
                returnQueue.Push(cur);
                CodeTile to = cur;
                CodeTile from = visitedTiles[to];
                while (from != startTile && from != null)
                {
                    returnQueue.Push(from);
                    to = from;
                    if (visitedTiles.ContainsKey(to))
                    {
                        from = visitedTiles[to];
                    }
                    else
                    {
                    
                    }
                }

                return returnQueue;
            }

            // Target has not been found, push all neighbors not yet visited:
            else
            {
                CodeTile t = cur.TileAbove;
                if (t != null && t.isPath && !visitedTiles.ContainsKey(t))
                {
                    tileQueue.Enqueue(t);
                    visitedTiles[t] = cur;
                }

                t = cur.TileRight;
                if (t != null && t.isPath && !visitedTiles.ContainsKey(t))
                {
                    tileQueue.Enqueue(t);
                    visitedTiles[t] = cur;
                }

                t = cur.TileBelow;
                if (t != null && t.isPath && !visitedTiles.ContainsKey(t))
                {
                    tileQueue.Enqueue(t);
                    visitedTiles[t] = cur;
                }

                t = cur.TileLeft;
                if (t != null && t.isPath && !visitedTiles.ContainsKey(t))
                {
                    tileQueue.Enqueue(t);
                    visitedTiles[t] = cur;
                }
            } // end else (not found)
        } // end while-queue size > 0

        return returnQueue;
    }


}
