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

    public List<Clickable> GenerateTreesPos(int posX, int posY, int min, int max)
    {
        int numTrees = Random.Range(min, max);
        List<Clickable> createdTrees = new List<Clickable>();
        Clickable tree;
        for (int i = 0; i < numTrees; i++)
        {
            tree = GameObject.Instantiate(ClickTree);
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
            float offsetX = Random.Range(0.2f, 0.8f);
            float offsetY = Random.Range(0.5f, 1.3f);
            tree.transform.position = new Vector2(posX + offsetX,  posY + offsetY);
            float scale = Random.Range(-0.2f, 0.2f);
            tree.transform.localScale = new Vector3(1 + scale, 1 + scale, 1);
            createdTrees.Add(tree);
        }
        return createdTrees;
    }


    public List<Clickable> GenerateStonesPos(int posX, int posY, int min, int max)
    {
        int numStones = Random.Range(min, max);
        List<Clickable> createdStones = new List<Clickable>();
        Clickable stone;
        for (int i = 0; i < numStones; i++)
        {
            stone = GameObject.Instantiate(ClickStone);
            int type = Random.Range(1, 6);
            switch (type)
            {
                case 1: { stone.rend.sprite = Stone1; break; }
                case 2: { stone.rend.sprite = Stone2; break; }
                case 3: { stone.rend.sprite = Stone3; break; }
                case 4: { stone.rend.sprite = Stone4; break; }
                case 5: { stone.rend.sprite = Stone5; break; }
                case 6: { stone.rend.sprite = Stone6; break; }
                default: { stone.rend.sprite = Stone1; break; }
            }
            float offsetX = Random.Range(0.2f, 0.8f);
            float offsetY = Random.Range(0.2f, 0.8f);
            stone.transform.position = new Vector2(posX + offsetX,  posY + offsetY);
            float scale = System.Math.Max(Random.Range(0.2f, 0.9f) - numStones, 0);
            stone.transform.localScale = new Vector3(1 + scale, 1 + scale, 1);
            createdStones.Add(stone);
        }
        return createdStones;
    }

}
