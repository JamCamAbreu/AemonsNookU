using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public abstract class CardGroup : MonoBehaviour
{
    public Card cardAsset;
    public Player player;
    public World world;
    public NotificationCanvas notificationCanvas;

    public CardDeck deck;
    public CardHand hand;
    public CardDiscard discard;

    public List<Card> cards = new List<Card>();

    public abstract Card.CardState cardState { get; }


    public virtual void Shuffle()
    {
        throw new NotImplementedException();
    }

    public void AddCard(Card card, bool addToFront = false)
    {
        if (addToFront)
        {
            cards.Insert(0, card);
        }
        else
        {
            cards.Add(card);
        }

        card.state = cardState;
        card.transform.SetParent(this.transform);

        DebugNameCards();
    }


    public virtual void DebugNameCards()
    {
        int i = 1;
        foreach (Card card in cards)
        {
            card.name = $"card {i}";
            i++;
        }
    }

    public virtual void PositionCards() { }

    public virtual Card PullFirstCard()
    {
        if (cards.Count > 0)
        {
            var deleteCard = cards[0];
            cards.RemoveAt(0);
            return deleteCard;
        }
        else
        {
            return null;
        }
    }

    public virtual Card PullLastCard()
    {
        if (cards.Count > 0)
        {
            var deleteCard = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return deleteCard;
        }
        else
        {
            return null;
        }
    }

}
