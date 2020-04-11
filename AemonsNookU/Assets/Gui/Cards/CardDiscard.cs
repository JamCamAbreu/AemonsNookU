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

    public bool SendingCardsToDeck { get; set; }
    public int SendingCardsToDeckAlarm { get; set; }
    public int SendingCardsToDeckAlarmReset { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        TargetPosition = this.transform.position;
        NormalPosition = this.transform.position;
        HidePosition = new Vector2(this.NormalPosition.x, this.NormalPosition.y - 40f);

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

        SendingCardsToDeck = false;
        SendingCardsToDeckAlarm = 0;
        SendingCardsToDeckAlarmReset = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PositionCards();
        DebugKeys();
        CheckSendingCardsToDeck();
        UpdateScale();

        this.transform.position = GlobalMethods.Ease((Vector2)this.transform.position, TargetPosition, 0.1f);
    }

    public void CheckSendingCardsToDeck()
    {
        if (SendingCardsToDeck)
        {
            if (cards.Count > 0)
            {
                if (SendingCardsToDeckAlarm > 0) { SendingCardsToDeckAlarm--; }
                else
                {
                    Card card = PullLastCard();
                    card.BeginFlip();
                    this.deck.AddCard(card, true, true);
                    SendingCardsToDeckAlarm = SendingCardsToDeckAlarmReset;
                }

            }
            else
            {
                this.deck.DelayShuffleExplode(45, 70);
                SendingCardsToDeck = false;
            }
        }
    }


    public override void PositionCards()
    {
        if (cards.Count > 0)
        {
            float parentX = this.TargetPosition.x;
            float parentY = this.TargetPosition.y;

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


    public void SendCardsToDeck(int transitionInterval)
    {
        SendingCardsToDeck = true;
        SendingCardsToDeckAlarm = transitionInterval;
        SendingCardsToDeckAlarmReset = transitionInterval;

    }

    public void DebugKeys()
    {
        if (Input.GetKeyDown("9"))
        {
            if (cards.Count > 0)
            {
                SendCardsToDeck(Math.Max(25/cards.Count, 1));
            }
        }
    }


}
