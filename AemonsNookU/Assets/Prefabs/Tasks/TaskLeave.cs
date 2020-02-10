using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TaskLeave : Task
{
    public string departureMessage;
    public TaskLeave(Peep myPeep)
    {
        MyPeep = myPeep;
        departureMessage = $"{MyPeep.FirstName} {MyPeep.SirName} has left.";
    }

    public override bool Step()
    {
        MyPeep.notificationCanvas.AddNotification(Notification.Type.peepDeparture, departureMessage);
        MyPeep.DepartLevel();
        return true;
    }
}
