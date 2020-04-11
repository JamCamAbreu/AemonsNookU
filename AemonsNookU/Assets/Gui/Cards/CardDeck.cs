using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardDeck : CardGroup
{

    public override Card.CardState cardState
    {
        get
        {
            return Card.CardState.deck;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DelayShuffle = false;
        DelayShuffleTimer = 0;
        DelayShuffleRadius = 0;
        TargetPosition = this.transform.position;
        NormalPosition = this.transform.position;
        HidePosition = new Vector2(this.NormalPosition.x, this.NormalPosition.y - 40f);
    }

    // Update is called once per frame
    void Update()
    {
        DebugKeys();
        CheckDelayShuffleTimer();
        UpdateScale();

        this.transform.position = GlobalMethods.Ease((Vector2)this.transform.position, TargetPosition, 0.1f);
    }

    #region Interface

    public void DrawCardToHand()
    {
        var deleteCard = PullFirstCard();
        deleteCard.BeginFlip();
        hand.AddCard(deleteCard);

        PositionCards();
        DebugNameCards();
    }

    public void DrawCardFromBottomToHand()
    {
        var deleteCard = PullLastCard();
        deleteCard.BeginFlip();
        hand.AddCard(deleteCard);

        PositionCards();
        DebugNameCards();
    }

    public Stack<Card> ScryX(int numCards)
    {
        throw new NotImplementedException();
    }

    protected virtual void _Shuffle(int passes)
    {
        if (cards.Count > 1)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < cards.Count; i++) { indices.Add(i); }

            System.Random rng = new System.Random();
            for (int i = 0; i < passes; i++)
            {
                int n = indices.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    int temp = indices[k];
                    indices[k] = indices[n];
                    indices[n] = temp;
                }
            }

            string newOrder = "new order: ";
            indices.ForEach(ind => newOrder += ind.ToString() + ", ");
            Debug.Log(newOrder);

            int j = 0;
            List<Card> newPositions = new List<Card>(cards);
            foreach (Card card in cards)
            {
                card.transform.SetParent(null);
                newPositions[indices[j]] = card;
                j++;
            }
            for (int i = 0; i < newPositions.Count; i++)
            {
                newPositions[newPositions.Count - 1 - i].transform.SetParent(this.transform);
            }
            this.cards = newPositions;
        }
    }


    public bool DelayShuffle { get; set; }
    public int DelayShuffleTimer { get; set; }
    public int DelayShuffleRadius { get; set; }
    public void CheckDelayShuffleTimer()
    {
        if (DelayShuffle)
        {
            if (DelayShuffleTimer > 0) { DelayShuffleTimer--; }
            else
            {
                ShuffleExplode(DelayShuffleRadius);
                DelayShuffle = false;
            }
        }
    }
    public void DelayShuffleExplode(int timer, int radius)
    {
        DelayShuffle = true;
        DelayShuffleTimer = timer;
        DelayShuffleRadius = radius;
    }

    public void ShuffleExplode(int radius)
    {
        System.Random rng = new System.Random();
        float ranX;
        float ranY;
        int handX = (int)this.transform.position.x;
        int handY = (int)this.transform.position.y;

        foreach (Card card in cards)
        {
            ranX = (float)rng.Next(handX + -radius, handX + radius);
            ranY = (float)rng.Next(handY + -radius, handY + radius);
            card.transitionType = Card.TransitionType.DeckExplode;
            card.TargetPos = new Vector2(ranX, ranY);
        }
    }

    public void CheckTransitionComplete(Card card)
    {
        if (cards.Where(c => c.transitionType == Card.TransitionType.None).Count() >= cards.Count*(3/4))
        {
            foreach (Card c in cards)
            {
                if (c.transitionType == Card.TransitionType.DeckExplode)
                {
                    c.transitionType = Card.TransitionType.None;
                }
            }

            _Shuffle(2);
            PositionCards();
            DebugNameCards();
        }
    }

    #endregion interface


    public override void PositionCards()
    {
        if (cards.Count > 0)
        {
            float deckX = this.TargetPosition.x;
            float deckY = this.TargetPosition.y;

            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].TargetPos = new Vector2(deckX - i*2, deckY + i*2);
            }
        }
    }


    public void DebugKeys()
    {

        if (Input.GetKeyDown("1"))
        {
            Vector2 spawnPos = new Vector2(this.transform.position.x + 10, this.transform.position.y - 50);
            Card debugCard = Instantiate(cardAsset, spawnPos, this.transform.rotation, this.transform);
            debugCard.transform.rotation = Quaternion.Euler(0, 0, -40);
            debugCard.TargetRot = Quaternion.Euler(0, 0, 0);
            debugCard.deck = this;
            debugCard.hand = this.hand;
            debugCard.discard = this.discard;
            debugCard.state = Card.CardState.deck;
            debugCard.SetCardSide(Card.Side.Back);

            notificationCanvas.AddNotification(Notification.Type.userAction, $"Adding card to hand.");
            AddCard(debugCard, true);

            PositionCards();
            DebugNameCards();
        }

        if (Input.GetKeyDown("2"))
        {
            if (cards.Count > 0)
            {
                DrawCardToHand();
            }
        }

        if (Input.GetKeyDown("0"))
        {
            if (cards.Count > 0)
            {
                ShuffleExplode((int)(100 * this.transform.localScale.x));
            }
        }


    }




}
