using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeepGenerator : MonoBehaviour
{
    public Sprite Aqua;
    public Sprite Armor;
    public Sprite Blue;
    public Sprite Brown;
    public Sprite Green;
    public Sprite Grey;
    public Sprite Purple;
    public Sprite Red;
    public Sprite Royal;
    public Sprite White;

    // This class will have an interface and be USED by the World class.
    public World MyWorld;
    public int CreationAlarmResetMin;
    public int CreationAlarmResetMax;
    public int CreationAlarm;
    public Peep peepPrefab;
    public NotificationCanvas notificationCanvas;

    public List<Peep> Peeps = new List<Peep>();
    public int MaxPeeps;

    public bool Started;
    public List<CodeTile> SpawnRoadTiles = new List<CodeTile>();
    public List<CodeTile> AllRoadTiles = new List<CodeTile>();

    private void Awake()
    {
        Started = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreationAlarmResetMin = 60 * 2; // get from level
        CreationAlarmResetMax = 60 * 6; // get from level
        CreationAlarm = CreationAlarmResetMax;
        MaxPeeps = 35; // get from level
    }

    // Update is called once per frame
    void Update()
    {
        CreationAlarm--;
        if (CreationAlarm <= 0)
        {
            if (Peeps.Count < MaxPeeps)
            {
                Peeps.Add(GeneratePeep());
            }

            CreationAlarm = Random.Range(CreationAlarmResetMin, CreationAlarmResetMax);
        }
    }


    public CodeTile GetRandomRoadTile()
    {
        return MyWorld.GetRandomRoadTile();
    }
    public CodeTile GetRandomExitTile()
    {
        return MyWorld.GetRandomExitTile();
    }

    public Peep GeneratePeep()
    {
        if (SpawnRoadTiles.Count > 0)
        {
            Peep peep = Object.Instantiate(peepPrefab);
            peep.name = $"{peep.Type.ToString()} - {peep.FirstName} {peep.SirName}";
            peep.transform.SetParent(this.MyWorld.peepList.transform);
            peep.MyPeepGenerator = this;
            peep.notificationCanvas = notificationCanvas;
            UpdatePeepCloths(peep);

            int randomStartIndex = Random.Range(0, SpawnRoadTiles.Count - 1);
            CodeTile startTile = SpawnRoadTiles[randomStartIndex];
            peep.OnTopOfTile = startTile;
            peep.pos = new Vector3(startTile.posX + 0.5f, startTile.posY + 0.5f, 1);

            CodeTile ranRoad = GetRandomRoadTile();

            peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));

            // Create notification to user
            string arrivalMessage = $"{peep.FirstName} {peep.SirName} has arrived!";
            notificationCanvas.AddNotification(Notification.Type.peepArrival, arrivalMessage);

            return peep;
        }
        else
        {
            return null;
        }
    }

    public bool CheckNecessaryTasks(Peep peep)
    {
        if (peep.FatiguePoints <= 0)
        {
            notificationCanvas.AddNotification(Notification.Type.peepDeparture, $"{peep.FirstName} {peep.SirName} is tired, going home.");
            CodeTile ranExitTile = GetRandomExitTile();

            if (AllRoadTiles.Contains(ranExitTile))
            {
                peep.MyTasks.Push(new TaskLeave(peep));
                peep.MyTasks.Push(new TaskWalk(peep, ranExitTile, AllRoadTiles, true));

                return true;
            }
        }

        // No necessary tasks
        return false;
    }


    public void GenerateNextTask(Peep peep)
    {
        bool hasTask = CheckNecessaryTasks(peep);

        if (!hasTask)
        {
            switch (peep.Type)
            {
                case PeepInfo.Type.child: this.GenerateTaskChild(peep); break;
                case PeepInfo.Type.homeless: this.GenerateTaskHomeless(peep); break;
                case PeepInfo.Type.thief: this.GenerateTaskThief(peep); break;
                case PeepInfo.Type.farmer: this.GenerateTaskFarmer(peep); break;
                case PeepInfo.Type.trader: this.GenerateTaskTrader(peep); break;
                case PeepInfo.Type.bard: this.GenerateTaskBard(peep); break;
                case PeepInfo.Type.monk: this.GenerateTaskMonk(peep); break;
                case PeepInfo.Type.nun: this.GenerateTaskNun(peep); break;
                case PeepInfo.Type.priest: this.GenerateTaskPriest(peep); break;
                case PeepInfo.Type.bishop: this.GenerateTaskBishop(peep); break;
                case PeepInfo.Type.knight: this.GenerateTaskKnight(peep); break;
                case PeepInfo.Type.quester: this.GenerateTaskQuester(peep); break;
                case PeepInfo.Type.foreigner: this.GenerateTaskForeigner(peep); break;
                case PeepInfo.Type.witch: this.GenerateTaskWitch(peep); break;
                case PeepInfo.Type.elder: this.GenerateTaskElder(peep); break;
                case PeepInfo.Type.wizard: this.GenerateTaskWizard(peep); break;
                case PeepInfo.Type.lady: this.GenerateTaskLady(peep); break;
                case PeepInfo.Type.king: this.GenerateTaskKing(peep); break;
                default: break;
            }
        }


    }

    #region GENERATE TASKS BASED ON TYPE Of PEEP
    public void GenerateTaskChild(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskHomeless(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskThief(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskFarmer(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskTrader(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskBard(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskMonk(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskNun(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskPriest(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskBishop(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskKnight(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskQuester(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskForeigner(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskWitch(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskElder(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskWizard(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskLady(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }

    public void GenerateTaskKing(Peep peep)
    {
        CodeTile ranRoad = GetRandomRoadTile();
        peep.MyTasks.Push(new TaskWalk(peep, ranRoad, AllRoadTiles, false));
    }
    #endregion


    public void UpdatePeepCloths(Peep p)
    {
        switch (p.Type)
        {
            case PeepInfo.Type.child:
                p.rend.sprite = Green;
                break;

            case PeepInfo.Type.homeless:
            case PeepInfo.Type.thief:
                p.rend.sprite = Grey;
                break;

            case PeepInfo.Type.farmer:
            case PeepInfo.Type.trader:
            case PeepInfo.Type.bard:
                p.rend.sprite = Brown;
                break;

            case PeepInfo.Type.monk:
            case PeepInfo.Type.nun:
            case PeepInfo.Type.priest:
            case PeepInfo.Type.bishop:
                p.rend.sprite = Purple;
                break;

            case PeepInfo.Type.knight:
                p.rend.sprite = Armor;
                break;

            case PeepInfo.Type.quester:
                p.rend.sprite = Red;
                break;

            case PeepInfo.Type.foreigner:
                p.rend.sprite = Blue;
                break;

            case PeepInfo.Type.witch:
                p.rend.sprite = Aqua;
                break;

            case PeepInfo.Type.elder:
            case PeepInfo.Type.wizard:
                p.rend.sprite = White;
                break;

            case PeepInfo.Type.lady:
            case PeepInfo.Type.king:
                p.rend.sprite = Royal;
                break;

            default:
                p.rend.sprite = Blue;
                break;
        }

    }

}
