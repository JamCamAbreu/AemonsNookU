using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardArea : MonoBehaviour
{

    public CardDeck deck;
    public CardHand hand;
    public CardDiscard discard;

    public float ActiveSize;
    public float HiddenSize;

    private bool lastFrameWasShow = false;

    public void Show()
    {
        hand.TargetScale = new Vector2(ActiveSize, ActiveSize);
        hand.TargetPosition = hand.NormalPosition;

        deck.TargetScale = new Vector3(ActiveSize, ActiveSize);
        deck.TargetPosition = deck.NormalPosition;

        discard.TargetScale = new Vector3(ActiveSize, ActiveSize);
        discard.TargetPosition = discard.NormalPosition;
    }

    public void Hide()
    {
        hand.TargetScale = new Vector3(HiddenSize, HiddenSize);
        hand.TargetPosition = hand.HidePosition;

        deck.TargetScale = new Vector3(HiddenSize, HiddenSize);
        deck.TargetPosition = deck.HidePosition;

        discard.TargetScale = new Vector3(HiddenSize, HiddenSize);
        discard.TargetPosition = discard.HidePosition;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            Show();

            if (!lastFrameWasShow)
            {
                this.deck.PositionCards();
            }

            lastFrameWasShow = true;
        }
        else
        {
            Hide();

            if (lastFrameWasShow)
            {
                //this.deck.PositionCards();
            }
            lastFrameWasShow = false;
        }
        
    }
}
