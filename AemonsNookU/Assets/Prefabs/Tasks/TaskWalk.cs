using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TaskWalk : Task
{
    public CodeTile StartTile { get; set; }
    public CodeTile TargetTile { get; set; }
    public List<CodeTile> AllRoads { get; set; }
    public Stack<CodeTile> MyPath { get; set; }

    public Vector2 prevFacingPos { get; set; }
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
        //Debug.Log($"Generated path with {this.MyPath.Count} steps between tile {StartTile.posX},{StartTile.posY} and target {TargetTile.posX},{TargetTile.posY}");

        this.curStep = this.StartTile;
        this.nextStep = this.GetNextStep();
        this.prevFacingPos = this.MyPeep.pos;

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
                bool hasStamina = this.MyPeep.DepleteStamina(1);
                if (!hasStamina)
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

        Vector2 prevPos = new Vector2(this.curStep.posX + cen, this.curStep.posY + cen);
        Vector2 targetFacingPos = new Vector2(this.nextStep.posX + cen, this.nextStep.posY + cen);
        targetFacingPos = RetrieveFacingPositionOnRoad(targetFacingPos, 0.25f);

        float dist = Vector2.Distance(this.MyPeep.pos, targetFacingPos);
        if (dist < 0.5f)
        {
            this.MyPeep.OnTopOfTile = this.nextStep;
        }
        if (dist <= closeGap)
        {
            this.MyPeep.pos = targetFacingPos;
            this.prevFacingPos = targetFacingPos;
            this.curStep = nextStep;
        }
        else
        {
            if (this.MyPeep.WalkType == PeepInfo.WalkType.ease)
            {
                this.MyPeep.pos = GlobalMethods.Ease((Vector2)this.MyPeep.transform.position, targetFacingPos, 0.15f / this.MyPeep.WalkSpeed);
            }
            else
            {
                float dividend = 30.0f * this.MyPeep.WalkSpeed;

                float distX = (targetFacingPos.x - prevFacingPos.x) / dividend;
                float distY = (targetFacingPos.y - prevFacingPos.y) / dividend;

                float newX = this.MyPeep.pos.x + distX;
                float newY = this.MyPeep.pos.y + distY;

                this.MyPeep.pos = new Vector2(newX, newY);
            }

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

    public Vector2 RetrieveFacingPositionOnRoad(Vector2 target, float amount)
    {
        Vector2 newTarget = target;
        CodeTile cur = this.curStep;
        CodeTile next = this.nextStep;

        if (next == cur.TileAbove)
        {
            newTarget.x += amount;
        }
        else if (next == cur.TileRight)
        {
            newTarget.y -= amount;
        }
        else if (next == cur.TileBelow)
        {
            newTarget.x -= amount;
        }
        else if (next == cur.TileLeft)
        {
            newTarget.y += amount;
        }
        return newTarget;
    }

}
