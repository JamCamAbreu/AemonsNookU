﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardHand hand { get; set; }
    Vector3 cachedScale;
    public int cardNum;

    // Start is called before the first frame update
    void Start()
    {
         cachedScale = transform.localScale;
    }


    // Update is called once per frame
    void Update()
    {
        
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
