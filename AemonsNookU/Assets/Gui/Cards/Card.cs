using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    public enum TransitionType
    {
        None,
        DeckExplode,
        UseCard
    }
    public int TransitionTimer { get; set; }

    public CardUI cardUI;

    public TransitionType transitionType { get; set; }

    public enum FlipState
    {
        None,
        StartFlip,
        EndFlip
    }

    public enum CardState
    {
        deck,
        hand,
        discard
    }

    public enum Side
    {
        Front,
        Back
    }


    public Side FacingSide { get; set; }

    public Vector2 TargetPos { get; set; }

    public Quaternion TargetRot { get; set; }
    public Vector2 TargetScale;

    public CardState state { get; set; }
    public CardDeck deck { get; set; }
    public CardHand hand { get; set; }
    public CardDiscard discard { get; set; }

    FlipState flipState { get; set; }


    Vector3 cachedScale;
    public int cardNum;

    // Start is called before the first frame update
    void Start()
    {
        this.FacingSide = Side.Back;
        this.cachedScale = transform.localScale;
        if(TargetPos == null) { TargetPos = this.transform.position; }
        if (TargetRot == null) { TargetRot = this.transform.rotation; }
        this.TargetScale = new Vector2(1, 1);
        this.flipState = FlipState.None;
        this.transitionType = TransitionType.None;
        this.TransitionTimer = 0;
    }


    // Update is called once per frame
    void Update()
    {
        DebugKeys();

        UpdatePosition();
        UpdateRotation();
        UpdateScale();

        UseCardTransition();
    }


    public void SetCardSide(Side side)
    {
        this.cardUI.SetCardSide(side);

        if (side == Side.Back)
        {
            this.FacingSide = Side.Back;
        }
        else if (side == Side.Front)
        {
            this.FacingSide = Side.Front;
        }
    }


    public void UseCardTransition()
    {
        if (this.transitionType == TransitionType.UseCard)
        {
            if (this.TransitionTimer > 0) { this.TransitionTimer--; }
            else
            {
                this.transitionType = TransitionType.None;
                this.discard.AddCard(this);
                this.TargetScale = new Vector2(1, 1);
                this.hand.ChosenCard = null;

                PerformAction();
            }
        }
    }

    public virtual void PerformAction()
    {
    }


    public void BeginFlip()
    {
        this.TargetRot = Quaternion.Euler(this.transform.rotation.x, 150, this.transform.rotation.z);
        this.flipState = FlipState.StartFlip;
    }

    public void DebugKeys()
    {
        if (Input.GetKeyDown("3")) {
            BeginFlip();
        }
    }



    protected void UpdatePosition()
    {
        this.transform.position = GlobalMethods.Ease((Vector2)this.transform.position, TargetPos, 0.1f);

        if (this.transitionType != TransitionType.None && Vector2.Distance((Vector2)this.transform.position, this.TargetPos) <= 2f)
        {
            if (this.transitionType == TransitionType.DeckExplode)
            {
                this.transitionType = TransitionType.None;
                this.deck.CheckTransitionComplete(this);
            }

        }
    }


    protected void UpdateScale()
    {
        this.transform.localScale = GlobalMethods.Ease((Vector2)this.transform.localScale, TargetScale, 0.1f);
    }



    protected void UpdateRotation()
    {
        this.transform.rotation = GlobalMethods.Ease((Quaternion)this.transform.rotation, TargetRot, 0.1f);

        // Check for flip:
        if (this.flipState == FlipState.StartFlip && Mathf.Abs(this.transform.rotation.eulerAngles.y) >= 89f)
        {
            if (FacingSide == Side.Back) { SetCardSide(Side.Front); }
            else { SetCardSide(Side.Back); }

            this.TargetRot = Quaternion.Euler(this.transform.rotation.x, 0, this.transform.rotation.z);
            this.flipState = FlipState.EndFlip;
        }
        else if (this.flipState == FlipState.EndFlip && Mathf.Abs(this.transform.rotation.eulerAngles.y) <= 1f)
        {
            this.flipState = FlipState.None;
        }
    }

    public void MouseEnterClosestCard()
    {
        this.cachedScale = this.TargetScale;
        this.TargetScale = new Vector3(2.0f, 2.0f, 2.0f);
        transform.SetAsLastSibling();
    }

    public void MouseExitClosestCard()
    {
        if (this.transitionType == TransitionType.None)
        {
            this.TargetScale = cachedScale;
        }

        transform.SetSiblingIndex(cardNum);
    }

}
