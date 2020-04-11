using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHand : CardGroup
{
    // Interface:
    public int maxHandSize;
    public float MinDistance = 30f;
    public Card selectedCard { get; set; }

    public int SpreadAngle; // 180

    // Hidden:
    public int SpacePerCard { get; set; }
    public float radius { get; set; } // = 60;  // distance in pixels
    public int CenterAngle { get { return 90; } }

    public Card lastClosest { get; set; }
    public Card ClosestCard
    {
        get
        {
            if (cards.Count > 0)
            {
                double closestDistance = MinDistance;
                Card closest = null;

                Vector2 mousePos = Input.mousePosition;
                //Vector2 mousePos = Camera.main.ScreenToWorldPoint(mouse);
                foreach (Card card in cards)
                {
                    float distanceToMouse = Vector2.Distance(mousePos, card.transform.position);
                    if (distanceToMouse < closestDistance)
                    {
                        closest = card;
                        closestDistance = distanceToMouse;
                    }
                }
                return closest;
            }
            else
            {
                return null;
            }
        }
    }

    public override Card.CardState cardState
    {
        get
        {
            return Card.CardState.hand;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TargetPosition = this.transform.position;
        NormalPosition = this.transform.position;
        HidePosition = new Vector2(this.NormalPosition.x, this.NormalPosition.y - 40f);
    }

    // Update is called once per frame
    void Update()
    {
        CheckCardsHover();
        CheckClick();
        PositionCards();
        UpdateScale();

        this.transform.position = GlobalMethods.Ease((Vector2)this.transform.position, TargetPosition, 0.1f);
    }

    public void CheckCardsHover()
    {
        Card closest = ClosestCard;
        if (closest != null)
        {
            if (closest != lastClosest)
            {
                if (lastClosest != null) { lastClosest.MouseExitClosestCard(); }
                closest.MouseEnterClosestCard();
                lastClosest = closest;
            }
        }
        else
        {
            if (lastClosest != null)
            {
                lastClosest.MouseExitClosestCard();
                lastClosest = null;
            }
        }
    }


    public void CheckClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Card closest = ClosestCard;
            if (closest != null)
            {
                this.cards.Remove(closest);
                this.discard.AddCard(closest);

                this.PositionCards();
                this.DebugNameCards();
            }
        }
    }



    public override void PositionCards()
    {
        if (cards.Count > 0)
        {
            float handX = this.TargetPosition.x;
            float handY = this.TargetPosition.y;

            int numCards = cards.Count;

            SpacePerCard = numCards == 1 ? 0 : SpreadAngle / numCards;
            int fullSpread = SpacePerCard * (numCards - 1);
            radius = (float)System.Math.Pow((numCards - 1), 0.5f) * 50;
            int position = 1;
            foreach (Card card in cards)
            {
                // Position
                float prePos = (CenterAngle - (fullSpread / 2) + (position - 1)*SpacePerCard) * Mathf.Deg2Rad;
                Vector2 pos = new Vector2(handX + Mathf.Cos(prePos) * radius, handY + Mathf.Sin(prePos) * (radius/4));
                card.TargetPos = pos;

                // rotation:
                float fullRotDeg = (float)System.Math.Pow((numCards - 1), 0.5f) * 14;
                float rotationPerCard = fullRotDeg / numCards;
                float zRot = (0 - fullRotDeg/2 + (position - 1)*rotationPerCard) * Mathf.Deg2Rad;
                card.TargetRot = new Quaternion(card.TargetRot.x, card.TargetRot.y, zRot, card.TargetRot.w);

                // Sibling Index:
                card.cardNum = position - 1;

                position++;
            }

        }
    }


}
