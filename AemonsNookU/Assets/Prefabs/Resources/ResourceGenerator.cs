using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{

    public Clickable ClickTree;
    public Sprite Tree1;
    public Sprite Tree2;
    public Sprite Tree3;
    public Sprite Tree4;
    public Sprite Tree5;
    public Sprite Tree6;

    public Clickable ClickStone;
    public Sprite Stone1;
    public Sprite Stone2;
    public Sprite Stone3;
    public Sprite Stone4;
    public Sprite Stone5;
    public Sprite Stone6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Clickable GenerateTree(int posX, int posY)
    {
        Clickable tree = GameObject.Instantiate(ClickTree);

        int type = Random.Range(1, 6);
        switch (type)
        {
            case 1: { tree.rend.sprite = Tree1; break; }
            case 2: { tree.rend.sprite = Tree2; break; }
            case 3: { tree.rend.sprite = Tree3; break; }
            case 4: { tree.rend.sprite = Tree4; break; }
            case 5: { tree.rend.sprite = Tree5; break; }
            case 6: { tree.rend.sprite = Tree6; break; }
            default: { tree.rend.sprite = Tree1; break; }
        }

        tree.transform.position = new Vector2(posX, posY);

        return tree;
    }


}
