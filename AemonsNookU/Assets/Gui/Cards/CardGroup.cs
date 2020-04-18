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
    public Vector2 TargetPosition { get; set; }
    public Vector2 NormalPosition { get; set; }
    public Vector2 HidePosition { get; set; }
    public Vector2 TargetScale { get; set; }
    public float HideTransformY;
    public float HideTransformX;


    public void AddCard(Card card, bool addToFront = false, bool reposition = false)
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

        if (reposition)
        {
            PositionCards();
        }

        DebugNameCards();
    }


    public virtual void DebugNameCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].name = $"card {i}";
        }
    }

    public virtual void PositionCards() { }

    public virtual void UpdateScale()
    {
        this.transform.localScale = GlobalMethods.Ease((Vector2)this.transform.localScale, TargetScale, 0.1f);
    }

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
