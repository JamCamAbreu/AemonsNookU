using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Assertions;

public class TaskWalk : Task
{
    public CodeTile StartTile { get; set; }
    public CodeTile TargetTile { get; set; }
    public List<CodeTile> AllRoads { get; set; }
    public Stack<CodeTile> MyPath { get; set; }

    public CodeTile curStep { get; set; }
    public CodeTile nextStep { get; set; }
    public bool IgnoresFatigue { get; set; }

    public TaskWalk(Peep peep, CodeTile targetTile, List<CodeTile> allRoads, bool ignoresFatigue)
    {
        this.MyPeep = peep;
        this.TaskType = TaskInfo.Type.WALK_RANDOM;
        this.StartTile = peep.OnTopOfTile;
        this.TargetTile = targetTile;
        this.AllRoads = allRoads;

        this.MyPath = TaskInfo.GenerateWalkQueue(this.StartTile, this.TargetTile, this.AllRoads);
        Debug.Log($"Generated path with {this.MyPath.Count} steps between tile {StartTile.posX},{StartTile.posY} and target {TargetTile.posX},{TargetTile.posY}");
        Assert.IsTrue(this.MyPath.Count > 0);

        this.curStep = this.StartTile;
        this.nextStep = this.GetNextStep();

        this.IgnoresFatigue = ignoresFatigue;
    }

    protected CodeTile GetNextStep()
    {
        if (MyPath.Count > 0) { return MyPath.Pop(); }
        else return null;
    }

    public override bool Step()
    {
        if (this.nextStep == null)
        {
            this.nextStep = GetNextStep();
        }

        // get new step, or finished:
        if (this.curStep == this.nextStep)
        {
            this.nextStep = GetNextStep();

            // Check fatigue and cancel if fatigued:
            if (!IgnoresFatigue)
            {
                this.MyPeep.FatiguePoints -= 1; // walking causes 1 fatigue per step
                if (MyPeep.FatiguePoints <= 0)
                {
                    return false;
                }
            }

            if (this.nextStep == null)
            {
                return false; // no more work to do!
            }
            this.SetPeepDirection();
        }

        float closeGap = 0.05f;
        float cen = 0.5f;
        Vector2 movePos = new Vector2(this.nextStep.posX + cen, this.nextStep.posY + cen);
        float dist = Vector2.Distance(this.MyPeep.pos, movePos);
        if (dist < 0.5f)
        {
            this.MyPeep.OnTopOfTile = this.nextStep;
        }
        if (dist <= closeGap)
        {
            this.MyPeep.pos = movePos;
            this.curStep = nextStep;
        }
        else
        {
            this.MyPeep.pos = GlobalMethods.Ease((Vector2)this.MyPeep.transform.position, movePos, 0.1f);
        }
        return true;
    }

    public void SetPeepDirection()
    {
        CodeTile cur = this.curStep;
        CodeTile next = this.nextStep;

        if (next == cur.TileAbove)
        {
            this.MyPeep.SetDirection(Peep.Direction.Up);
        }
        else if (next == cur.TileRight)
        {
            this.MyPeep.SetDirection(Peep.Direction.Right);
        }
        else if (next == cur.TileBelow)
        {
            this.MyPeep.SetDirection(Peep.Direction.Down);
        }
        else if (next == cur.TileLeft)
        {
            this.MyPeep.SetDirection(Peep.Direction.Left);
        }

    }

}
