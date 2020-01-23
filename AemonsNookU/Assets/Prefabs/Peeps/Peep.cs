using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peep : MonoBehaviour
{
    public Stack<Task> MyTasks { get; set; }
    public Task CurrentTask { get; set; }

    public PeepInfo.Type Type { get; set; }
    public string FirstName { get; set; }
    public string SirName { get; set; }
    public int Age { get; set; }
    public int Fame { get; set; }
    public int FatiguePoints { get; set; } // tasks cost fatigue points, points before tired and wants to leave

    // Resources (in pounds):
    public Dictionary<string, Item> Inventory { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        MyTasks = new Stack<Task>();
        Inventory = new Dictionary<string, Item>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
