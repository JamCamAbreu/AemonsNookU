using System;
using System.Collections.Generic;
using UnityEngine;

public class CardDiscard : CardGroup
{

    public int MaxPileWidth;
    public int MaxPileHeight;
    public int MaxPileSize = 300;
    List<int> ranXList { get; set; }
    List<int> ranYList { get; set; }

    public override Card.CardState cardState
    {
        get
        {
            return Card.CardState.discard;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);

        ranXList = new List<int>();
        ranYList = new List<int>();
        for (int i = 0; i < MaxPileSize; i++)
        {
            int ranX = UnityEngine.Random.Range(-(MaxPileWidth / 2), (MaxPileWidth / 2));
            int ranY = UnityEngine.Random.Range(-(MaxPileHeight / 2), (MaxPileHeight / 2));
            ranXList.Add(ranX);
            ranYList.Add(ranY);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PositionCards();
    }


    public override void PositionCards()
    {
        if (cards.Count > 0)
        {
            float parentX = this.transform.position.x;
            float parentY = this.transform.position.y;

            int i = 0;
            foreach (Card card in cards)
            {
                card.TargetPos = new Vector2(parentX + ranXList[i], parentY + ranYList[i]);

                if (card.transform.GetSiblingIndex() != i)
                {
                    card.transform.SetSiblingIndex(i);
                }

                i++;
            }
        }
    }

}
