using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugCoordinates : MonoBehaviour
{
    public World world;

    public CodeTile currentTile;

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

            currentTile = world.TileAt(worldX, worldY);

            CodeTile above = null;
            CodeTile right = null;
            CodeTile below = null;
            CodeTile left = null;
            if (currentTile != null)
            {
                above = currentTile.TileAbove;
                right = currentTile.TileRight;
                below = currentTile.TileBelow;
                left = currentTile.TileLeft;
            }

            text.text = $"{worldX},{worldY}";

            if (currentTile != null)
            {
                text.text += $"\t{currentTile.posX},{currentTile.posY}\n";
                if (above != null) { text.text += $"\t↑({above.posX},{above.posY})"; }
                if (right != null) { text.text += $"\t➝({right.posX},{right.posY})"; }
                if (below != null) { text.text += $"\t↓({below.posX},{below.posY})"; }
                if (left != null) { text.text += $"\t←({left.posX},{left.posY})"; }
                text.text += $"\nType: {currentTile.TileType}";
                string isEdge = currentTile.isMapEdge ? "yes" : "no";
                text.text += $"\nExit?: {isEdge}";
            }

            this.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y + 60);
        }
    }

}
