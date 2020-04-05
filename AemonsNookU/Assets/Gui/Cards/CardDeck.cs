using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{

    // Unity References:
    public CardHand hand;
    public CardDiscard discard;

    public Card cardAsset;
    public Player player;
    public World world;
    public NotificationCanvas notificationCanvas;

    // Non-Unity
    public Stack<Card> deck = new Stack<Card>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DebugKeys();
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

    public void Shuffle()
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

    public void DebugNameCards()
    {
        int i = 1;
        foreach (Card card in deck)
        {
            card.name = $"card {i}";
            i++;
        }
    }

    public void PositionCards()
    {
        if (deck.Count > 0)
        {
            float deckX = this.transform.position.x;
            float deckY = this.transform.position.y;

            int i = 0;
            foreach (Card card in deck)
            {
                card.transform.position = new Vector2(deckX + i*2, deckY + i*2);
                i++;
            }
        }
    }

    public void DebugKeys()
    {

        if (Input.GetKeyDown("1"))
        {
            Card debugCard = Instantiate(cardAsset, this.transform.position, this.transform.rotation, this.transform);
            debugCard.deck = this;
            debugCard.hand = this.hand;
            debugCard.discard = this.discard;
            debugCard.state = Card.CardState.deck;

            deck.Push(debugCard);
            notificationCanvas.AddNotification(Notification.Type.userAction, $"Adding card to hand.");

            PositionCards();
            DebugNameCards();
        }

        if (Input.GetKeyDown("2"))
        {
            if (deck.Count > 0)
            {
                var deleteCard = deck.Pop();
                deleteCard.transform.SetParent(this.hand.transform);
                deleteCard.state = Card.CardState.hand;
                this.hand.PositionCards();

                PositionCards();
                DebugNameCards();
            }
        }

    }




}
