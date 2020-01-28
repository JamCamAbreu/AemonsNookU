using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskWalkRandom : Task 
{
    public CodeTile StartTile { get; set; }
    public CodeTile TargetTile { get; set; }
    public List<CodeTile> AllRoads { get; set; }
    public Stack<CodeTile> MyPath { get; set; }

    public CodeTile curStep { get; set; }
    public CodeTile nextStep { get; set; }

    public TaskWalkRandom(Peep peep, CodeTile targetTile, List<CodeTile> allRoads)
    {
        this.MyPeep = peep;
        this.TaskType = TaskInfo.Type.WALK_RANDOM;
        this.StartTile = peep.OnTopOfTile;
        this.TargetTile = targetTile;
        this.AllRoads = allRoads;

        this.MyPath = TaskInfo.GenerateWalkQueue(this.StartTile, this.TargetTile, this.AllRoads);
        this.curStep = this.StartTile;
        this.nextStep = this.GetNextStep();
    }

    private CodeTile GetNextStep()
    {
        if (MyPath.Count > 0) { return MyPath.Pop(); }
        else return null;
    }

    public override bool Step()
    {
        if (this.nextStep == null)
        {
            return false;
        }

        // get new step, or finished:
        if (this.curStep == this.nextStep)
        {
            this.nextStep = GetNextStep();
            if (this.nextStep == null)
            {
                return false; // no more work to do!
            }
        }

        float closeGap = 0.05f;
        float cen = 0.5f;
        Vector2 movePos = new Vector2(this.nextStep.posX + cen, this.nextStep.posY + cen);
        if (Vector2.Distance(this.MyPeep.pos, movePos) <= closeGap)
        {
            this.MyPeep.pos = movePos;
            this.MyPeep.OnTopOfTile = this.curStep;
            this.curStep = nextStep;
        }
        else
        {
            this.MyPeep.pos = GlobalMethods.Ease((Vector2)this.MyPeep.transform.position, movePos, 0.1f);
        }
        return true;
    }


}
