using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TaskOccupyBuilding : Task
{
    public Building targetBuilding;
    public bool entered;

    public int insideTimer;

    public TaskOccupyBuilding(Peep myPeep, Building building)
    {
        MyPeep = myPeep;
        targetBuilding = building;
        entered = false;
    }




    public override bool Step()
    {

        if (!entered)
        {
            if (!targetBuilding.Entrances.Contains(MyPeep.OnTopOfTile))
            {
                string message = $"{MyPeep.FirstName} was not able to enter {targetBuilding.Name}.";
                MyPeep.notificationCanvas.AddNotification(Notification.Type.error, message);
                return false; // finished
            }
            else
            {
                int duration = (int)(RetrieveBaseOccupyTime() * this.MyPeep.RetrieveBuildingDurationMultiplier(targetBuilding.Type));
                this.insideTimer = duration;
                Debug.Log($"{MyPeep.FirstName} is entering the {targetBuilding.Name} for about {duration/60} seconds");
                this.EnterBuilding();
                entered = true;
            }
        }
        else
        {
            if (this.insideTimer <= 0)
            {
                this.ExitBuilding();
                return false; // finished
            }
            else
            {
                this.insideTimer--;

                if (this.insideTimer % 30 == 0)
                {
                    bool hasStamina = this.MyPeep.DepleteStamina(1);
                    if (!hasStamina)
                    {
                        this.ExitBuilding();
                        return false; // finished
                    }
                }

            }
        }

        return true; // continue
    }

    private int RetrieveBaseOccupyTime()
    {
        switch (targetBuilding.Type)
        {
            case BuildingInfo.Type.ARCHERY:
                return 60 * 8;

            case BuildingInfo.Type.BATH:
                return 60 * 12;

            case BuildingInfo.Type.BLACKSMITH:
                return 60 * 4;

            case BuildingInfo.Type.BOOTH_FISH:
                return 60 * 1;

            case BuildingInfo.Type.BOOTH_GEMS:
                return 60 * 3;

            case BuildingInfo.Type.BOOTH_PRODUCE:
                return 60 * 1;

            case BuildingInfo.Type.BOOTH_SEEDS:
                return 60 * 1;

            case BuildingInfo.Type.BUTCHER:
                return 60 * 2;

            case BuildingInfo.Type.CHAPEL:
                return 60 * 6;

            case BuildingInfo.Type.CLOTH:
                return 60 * 3;

            case BuildingInfo.Type.INN:
                return 60 * 10;

            case BuildingInfo.Type.SCRIBE:
                return 60 * 5;

            case BuildingInfo.Type.STABLES:
                return 60 * 5;

            case BuildingInfo.Type.TANNER:
                return 60 * 4;

            case BuildingInfo.Type.TAVERN:
                return 60 * 9;

            default:
                return 60 * 20;
        }

    }



    private void EnterBuilding()
    {
        this.MyPeep.Hide();
        this.targetBuilding.AddOccupant(this.MyPeep);
    }

    private void ExitBuilding()
    {
        this.targetBuilding.RemoveOccupant(this.MyPeep);
        MyPeep.Unhide();
    }



}
