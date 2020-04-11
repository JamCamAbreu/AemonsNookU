using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    public GameObject CardFront;
    public GameObject CardBack;
    public GameObject CardTitle;
    public GameObject Logo;


    public enum TransitionType
    {
        None,
        DeckExplode
    }

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
        this.flipState = FlipState.None;
        this.transitionType = TransitionType.None;
    }


    // Update is called once per frame
    void Update()
    {
        DebugKeys();

        UpdatePosition();
        UpdateRotation();
    }


    public void SetCardSide(Side side)
    {
        if (side == Side.Back)
        {
            CardFront.SetActive(false);
            CardBack.SetActive(true);
            CardTitle.SetActive(false);
            Logo.SetActive(false);
            this.FacingSide = Side.Back;
        }
        else if (side == Side.Front)
        {
            CardFront.SetActive(true);
            CardBack.SetActive(false);
            CardTitle.SetActive(true);
            Logo.SetActive(true);
            this.FacingSide = Side.Front;
        }
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
        transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        transform.SetAsLastSibling();
    }

    public void MouseExitClosestCard()
    {
        transform.localScale = cachedScale;
        transform.SetSiblingIndex(cardNum);
    }

}
