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
    public int CreationAlarmReset;
    public int CreationAlarm;
    public Peep peepPrefab;

    List<Peep> Peeps = new List<Peep>();

    public bool Started;
    public List<CodeTile> SpawnPoints = new List<CodeTile>();

    private void Awake()
    {
        Started = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreationAlarmReset = 60 * 5;
        CreationAlarm = CreationAlarmReset;
    }

    // Update is called once per frame
    void Update()
    {
        CreationAlarm--;
        if (CreationAlarm <= 0)
        {
            Peeps.Add(GeneratePeep());
            CreationAlarm = CreationAlarmReset;
        }
    }

    public Peep GeneratePeep()
    {
        if (SpawnPoints.Count > 0)
        {
            Peep peep = Object.Instantiate(peepPrefab);
            UpdatePeepCloths(peep);

            int randomStartIndex = Random.Range(0, SpawnPoints.Count - 1);
            CodeTile startTile = SpawnPoints[randomStartIndex];

            peep.transform.position = new Vector3(startTile.posX + 0.5f, startTile.posY + 0.5f, 1);
            return peep;
        }
        else
        {
            return null;
        }
    }

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
