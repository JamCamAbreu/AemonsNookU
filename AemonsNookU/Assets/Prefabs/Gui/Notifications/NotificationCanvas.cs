using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationCanvas : MonoBehaviour
{
    public GameObject PanelObj;
    private const int HEIGHT_TEXT = 20;
    public int NumRows;
    private List<Vector2> RowPositions = new List<Vector2>();
    private const float LEFT_MARGIN = 1.0f;
    private const float TOP_MARGIN = 24.0f;
    public List<Notification> notifications = new List<Notification>();
    public Notification NotificationPrefab;

    private RectTransform Panel
    {
        get
        {
            return PanelObj.GetComponent<RectTransform>();
        }
    }
    private float PanelPositionLeft
    {
        get
        {
            return PanelObj.transform.position.x + LEFT_MARGIN;
        }
    }

    private float PanelPositionTop
    {
        get
        {
            return Screen.height - TOP_MARGIN;
            //return height - TOP_MARGIN;
        }
    }

    private int height
    {
        get
        {
            return (int)Panel.rect.height;
        }
    }
    private int width
    {
        get
        {
            return (int)Panel.rect.width;
        }
    }

    public void UpdatePositions(int numRows)
    {
        RowPositions.Clear();
        for (int i = 0; i < numRows; i++)
        {
            RowPositions.Add(new Vector2(this.PanelPositionLeft, PanelPositionTop - (i * HEIGHT_TEXT)));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        NumRows = this.height / HEIGHT_TEXT;
        UpdatePositions(NumRows);
    }

    // Update is called once per frame
    void Update()
    {
        Notification note;
        for (int i = 0; i < notifications.Count; i++)
        {
            note = notifications[i];
            note.transform.position = GlobalMethods.Ease((Vector2)note.transform.position, RowPositions[i], 0.1f);
        }
        
    }


    private void RemoveOldest()
    {
        notifications.RemoveAt(notifications.Count - 1);
    }


    public void AddNotification(Notification.Type type, string text)
    {
        if (notifications.Count >= NumRows)
        {
            RemoveOldest();
        }

        // Spawn note just to the left
        Notification note = Instantiate(NotificationPrefab, new Vector2(RowPositions[0].x - 100, RowPositions[0].y), new Quaternion(0,0,0,0));
        note.MyParent = this;
        note.UpdateType(type);
        note.UpdateText(text);
        note.life = 60*6;
        note.maxFade = 60*5;
        note.curFade = 60*5;
        note.started = true;

        notifications.Insert(0, note);
        note.transform.SetParent(PanelObj.transform, false);
    }


    public void RemoveNotification(Notification note)
    {
        notifications.Remove(note);
    }


}
