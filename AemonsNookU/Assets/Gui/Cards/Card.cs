using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    public enum FlipFrom
    {
        FromLeft,
        FromRight
        // FromBottom
        // FromTop
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
    private int HasNewPosition { get; set; }

    public Quaternion TargetRot { get; set; }

    public CardState state { get; set; }
    public CardDeck deck { get; set; }
    public CardHand hand { get; set; }
    public CardDiscard discard { get; set; }



    Vector3 cachedScale;
    public int cardNum;

    // Start is called before the first frame update
    void Start()
    {
        FacingSide = Side.Back;
        cachedScale = transform.localScale;
        if(TargetPos == null) { TargetPos = this.transform.position; }
        if (TargetRot == null) { TargetRot = this.transform.rotation; }
    }


    // Update is called once per frame
    void Update()
    {
        if (HasNewPosition > 0)
        {
            if (HasNewPosition == 1)
            {
                this.TargetPos = this.transform.position;
            }
            HasNewPosition--;
        }
        else
        {
            UpdatePosition();
            UpdateRotation();
        }
    }


    public void SetCardSide(Side side)
    {
        if (side == Side.Back)
        {
            // set back visible = true
            // turn off other things
        }
        else if (side == Side.Front)
        {
            // set front visible = true
            // set back visible = false
            // turn on visibility of other things
        }
    }


    public void DebugKeys()
    {
        if (Input.GetKeyDown("3")) {
            Flip(0.5f, FlipFrom.FromLeft);
        }
    }

    public void Flip(float seconds, FlipFrom fromSide)
    {

    }


    protected void UpdatePosition()
    {
        this.transform.position = GlobalMethods.Ease((Vector2)this.transform.position, TargetPos, 0.1f);
    }

    protected void UpdateRotation()
    {
        this.transform.rotation = GlobalMethods.Ease((Quaternion)this.transform.rotation, TargetRot, 0.1f);
    }

    public void EnterClosest()
    {
        transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        transform.SetAsLastSibling();
    }

    public void ExitClosest()
    {
        transform.localScale = cachedScale;
        transform.SetSiblingIndex(cardNum);
    }

}
