using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugCoordinates : MonoBehaviour
{
    public World world;

    public Text text
    {
        get
        {
            return GetComponent<Text>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null)
        {
            Vector2 point = world.cameraPrefab.ScreenToWorldPoint(Input.mousePosition);
            int worldX = (int)point.x;
            int worldY = (int)point.y;
            text.text = $"{worldX},{worldY}";

            this.transform.position = Input.mousePosition;
        }
    }

}
