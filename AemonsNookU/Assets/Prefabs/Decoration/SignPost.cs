using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : MonoBehaviour
{

    public SpriteRenderer rend
    {
        get
        {
            return this.GetComponent<SpriteRenderer>();
        }
    }

    public enum Facing
    {
        up,
        right,
        down,
        left
    }

    public Sprite upSprite;
    public Sprite rightSprite;
    public Sprite downSprite;
    public Sprite leftSprite;

    public void SetFacingDirection(Facing fac)
    {
        switch (fac)
        {
            case Facing.up: rend.sprite = upSprite; break;
            case Facing.right: rend.sprite = rightSprite; break;
            case Facing.down: rend.sprite = downSprite; break;
            case Facing.left: rend.sprite = leftSprite; break;
            default: rend.sprite = upSprite; break;
        }
    }

    public void SetPosition(Vector2 target)
    {
        this.transform.position = target;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
