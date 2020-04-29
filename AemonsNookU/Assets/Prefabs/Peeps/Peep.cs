using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Peep : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }

    public SpriteRenderer rend { get { return this.GetComponent<SpriteRenderer>(); } }
    public Vector2 pos
    {
        get { return this.transform.position; }
        set { this.transform.position = value; }
    }

    // Special multiplier defined by child peep 
    public virtual float RetrieveBuildingDurationMultiplier(BuildingInfo.Type type)
    {
        switch (type)
        {
            default:
                return 1;
        }
    }


    public CodeTile OnTopOfTile { get; set; }

    public Stack<Task> MyTasks { get; set; }
    public Task CurrentTask { get; set; }
    public PeepGenerator MyPeepGenerator { get; set; }
    public NotificationCanvas notificationCanvas;

    public PeepInfo.Type Type;
    public PeepInfo.Sex Sex;
    public string FirstName;
    public string SirName;
    public int Age;
    public int Fame;
    public int Stamina; // tasks cost stamina points, points before tired and wants to leave

    private Animator feetAnimator;

    // Resources (in pounds):
    public Dictionary<string, Item> Inventory { get; set; }

    public virtual void Awake()
    {
        MyTasks = new Stack<Task>();
        Inventory = new Dictionary<string, Item>();

        int randomType = Random.Range(0, 17);
        PeepInfo.UpdatePeepType(this, (PeepInfo.Type)randomType);

        feetAnimator = GetComponentInChildren<Animator>();
    }

    public bool DepleteStamina (int amount)
    {
        Stamina -= amount;
        return (Stamina > 0);
    }

    public void Hide()
    {
        this.rend.enabled = false;
    }
    public void Unhide()
    {
        this.rend.enabled = true;
    }

    // Start is called before the first frame update
    public virtual void Start()
    {
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (CurrentTask == null)
        {
            if (MyTasks.Count > 0)
            {
                CurrentTask = MyTasks.Pop();
            }
            else
            {
                //Debug.Log($"{this.FirstName} {this.SirName} finished all tasks. Generating a new task.");
                MyPeepGenerator.GenerateNextTask(this);

                Assert.IsTrue(this.MyTasks.Count > 0);
            }
        }
        else
        {
            if (!CurrentTask.Step())
            {
                ClearCurrentTask();
            }
        }
    }

    public void ClearCurrentTask()
    {
        CurrentTask = null;
    }

    public void SetDirection(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                transform.rotation = Quaternion.Euler(0, 0, 90f);
                break;

            case Direction.Right:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;

            case Direction.Down:
                transform.rotation = Quaternion.Euler(0, 0, 270f);
                break;

            case Direction.Left:
                transform.rotation = Quaternion.Euler(0, 0, 180f);
                break;

            default:
                break;
        }
    }

    public void DepartLevel()
    {
        MyPeepGenerator.Peeps.Remove(this);
        Destroy(this.gameObject);
    }
}
