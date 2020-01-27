using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peep : MonoBehaviour
{

    public SpriteRenderer rend { get { return this.GetComponent<SpriteRenderer>(); } }

    public Stack<Task> MyTasks { get; set; }
    public Task CurrentTask { get; set; }

    public PeepInfo.Type Type;
    public PeepInfo.Sex Sex;
    public string FirstName;
    public string SirName;
    public int Age;
    public int Fame;
    public int FatiguePoints; // tasks cost fatigue points, points before tired and wants to leave

    // Resources (in pounds):
    public Dictionary<string, Item> Inventory { get; set; }

    private void Awake()
    {
        MyTasks = new Stack<Task>();
        Inventory = new Dictionary<string, Item>();

        int randomType = Random.Range(0, 17);
        PeepInfo.UpdatePeepType(this, (PeepInfo.Type)randomType);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
