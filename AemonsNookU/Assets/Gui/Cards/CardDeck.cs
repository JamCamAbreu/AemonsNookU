using System;
using System.Collections;
using System.Collections.Generic;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        DebugKeys();
        PositionCards();
    }

    #region Interface
    public void AddCardTop(Card card)
    {
        throw new NotImplementedException();
    }

    public void AddCardBottom(Card card)
    {
        throw new NotImplementedException();
    }

    public void AddCardRandom(Card card)
    {
        throw new NotImplementedException();
    }


    public Card DrawCard()
    {

        throw new NotImplementedException();
    }

    public Card DrawFromBottom()
    {
        throw new NotImplementedException();
    }

    public Stack<Card> ScryX(int numCards)
    {
        throw new NotImplementedException();
    }


    #endregion interface


    public override void PositionCards()
    {
        if (cards.Count > 0)
        {
            float deckX = this.transform.position.x;
            float deckY = this.transform.position.y;

            int i = 0;
            foreach (Card card in cards)
            {
                card.TargetPos = new Vector2(deckX - i*2, deckY + i*2);
                i++;
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
        }

        if (Input.GetKeyDown("2"))
        {
            if (cards.Count > 0)
            {
                var deleteCard = PullFirstCard();
                deleteCard.Flip();
                hand.AddCard(deleteCard);

                PositionCards();
                DebugNameCards();
            }
        }

    }




}
