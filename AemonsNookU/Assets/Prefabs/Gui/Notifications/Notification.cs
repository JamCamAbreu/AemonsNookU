using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public enum Type
    {
        userAction,
        tip,
        peepArrival,
        peepArrivalRoyal,
        peepDeparture,
        barfight,
        incomingWave,
        error
    }

    public int life;
    public bool started = false;
    public bool beginFade = false;
    public float curFade = 10; // overwritten
    public float maxFade = 10; // overwritten
    public NotificationCanvas MyParent;

    public Text backShadow
    {
        get
        {
            return this.GetComponent<Text>();
        }
    }
    public GameObject frontHighlightNode;
    public Text frontHighlight
    {
        get
        {
            return frontHighlightNode.GetComponent<Text>();
        }
    }

    public void UpdateType(Type t)
    {
        switch (t)
        {
            case Type.tip:
            case Type.userAction:
                this.frontHighlight.color = Color.white;
                break;

            case Type.peepArrival:
                this.frontHighlight.color = Color.green;
                break;

            case Type.peepArrivalRoyal:
                this.frontHighlight.color = Color.cyan;
                break;

            case Type.peepDeparture:
                this.frontHighlight.color = Color.grey;
                break;

            case Type.barfight:
                this.frontHighlight.color = Color.red;
                break;

            case Type.incomingWave:
                this.frontHighlight.color = Color.red;
                break;

            case Type.error:
                this.frontHighlight.color = new Color(1, 165f/255f, 0);
                break;

            default:
                break;
        }
    }

    public void UpdateText(string newText)
    {
        this.backShadow.text = newText;
        this.frontHighlight.text = newText;
    }

    public void UpdateTransparency(float newTransparency)
    {
        Color cur = this.frontHighlight.color;
        this.frontHighlight.color = new Color(cur.r, cur.g, cur.b, 255*newTransparency);

        cur = this.backShadow.color;
        this.backShadow.color = new Color(cur.r, cur.g, cur.b, 255*newTransparency);
    }

    public void Die()
    {
        MyParent.RemoveNotification(this);
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (started)
        {
            life--;
            if (life <= 0)
            {
                beginFade = true;
            }

            if (beginFade)
            {
                curFade--;
                if (curFade <= 0)
                {
                    Die();
                }

                if (maxFade != 0)
                {
                    UpdateTransparency(curFade / maxFade);
                }
            }

        }
    }
}
