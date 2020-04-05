using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHand : MonoBehaviour
{
    // Interface:
    public int maxHandSize;
    public float MinDistance = 30f;

    // Unity References:
    public CardDiscard discard;
    public CardDeck deck;

    public Card cardAsset;
    public Player player;
    public World world;
    public NotificationCanvas notificationCanvas;
    public int SpreadAngle; // 180

    // Hidden:
    public Queue<Card> slots = new Queue<Card>();
    public int SpacePerCard { get; set; }
    public float radius { get; set; } // = 60;  // distance in pixels
    public int CenterAngle { get { return 90; } }

    public Card lastClosest { get; set; }
    public Card ClosestCard
    {
        get
        {
            if (slots.Count > 0)
            {
                double closestDistance = MinDistance;
                Card closest = null;

                Vector2 mousePos = Input.mousePosition;
                //Vector2 mousePos = Camera.main.ScreenToWorldPoint(mouse);
                foreach (Card card in slots)
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DebugKeys();
        CheckHover();
    }



    public void CheckHover()
    {
        Card closest = ClosestCard;
        if (closest != null)
        {
            if (closest != lastClosest)
            {
                if (lastClosest != null) { lastClosest.ExitClosest(); }
                closest.EnterClosest();
                lastClosest = closest;
            }
        }
        else
        {
            if (lastClosest != null)
            {
                lastClosest.ExitClosest();
                lastClosest = null;
            }
        }
    }



    public void PositionCards()
    {
        if (slots.Count > 0)
        {
            float handX = this.transform.position.x;
            float handY = this.transform.position.y;

            int numCards = slots.Count;

            SpacePerCard = numCards == 1 ? 0 : SpreadAngle / numCards;
            int fullSpread = SpacePerCard * (numCards - 1);
            radius = (float)System.Math.Pow((numCards - 1), 0.5f) * 50;
            int position = 1;
            foreach (Card card in slots)
            {
                // Position
                float prePos = (CenterAngle - (fullSpread / 2) + (position - 1)*SpacePerCard) * Mathf.Deg2Rad;
                Vector2 pos = new Vector2(handX + Mathf.Cos(prePos) * radius, handY + Mathf.Sin(prePos) * (radius/4));

                card.transform.position = pos;

                // rotation:
                float fullRotDeg = (float)System.Math.Pow((numCards - 1), 0.5f) * 14;
                float rotationPerCard = fullRotDeg / numCards;
                float zRot = (0 - fullRotDeg/2 + (position - 1)*rotationPerCard) * Mathf.Deg2Rad;
                card.transform.rotation = new Quaternion(card.transform.rotation.x, card.transform.rotation.y, zRot, card.transform.rotation.w);

                // Sibling Index:
                card.cardNum = position - 1;

                position++;
            }

        }
    }

    public void DebugNameCards()
    {
        int i = 1;
        foreach (Card card in slots)
        {
            card.name = $"card {i}";
            i++;
        }
    }


    public void DebugKeys()
    {

        //if (Input.GetKeyDown("1"))
        //{
        //    if (slots.Count < maxHandSize)
        //    {
        //        Card debugCard = Instantiate(cardAsset, this.transform.position, this.transform.rotation, this.transform);
        //        debugCard.hand = this;
        //        slots.Enqueue(debugCard);
        //        notificationCanvas.AddNotification(Notification.Type.userAction, $"Adding card to hand.");

        //        PositionCards();
        //        DebugNameCards();
        //    }
        //    else
        //    {
        //        notificationCanvas.AddNotification(Notification.Type.userAction, $"Could not add card to hand, max hand size is {maxHandSize}");
        //    }

        //}

        //if (Input.GetKeyDown("2"))
        //{
        //    if (slots.Count > 0)
        //    {
        //        var deleteCard = slots.Dequeue();
        //        deleteCard.transform.SetParent(null);
        //        Object.Destroy(deleteCard);

        //        PositionCards();
        //        DebugNameCards();
        //    }
        //}

    }


}
