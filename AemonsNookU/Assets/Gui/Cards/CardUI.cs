using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public GameObject FrontObj;
    public GameObject BackObj;
    public GameObject TitleObj;
    public GameObject TitleBackObj;
    public GameObject LogoObj;
    public GameObject DescBackObj;
    public GameObject DescObj;

    public TextMeshProUGUI CardTitle { get { return this.TitleObj.GetComponent<TextMeshProUGUI>(); } }
    public Image CardTitleBackImage { get { return this.TitleBackObj.GetComponent<Image>(); } }
    public Image CardLogo { get { return this.LogoObj.GetComponent<Image>(); } }
    public Image CardFrontImage { get { return this.FrontObj.GetComponent<Image>(); } }
    public Image CardBackImage { get { return this.BackObj.GetComponent<Image>(); } }
    public TextMeshProUGUI CardDescription { get { return this.DescObj.GetComponent<TextMeshProUGUI>(); } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCardTitleBackColor(Color color)
    {
        this.CardTitleBackImage.color = color;
    }

    public void SetTitleBackWidth()
    {
        int numCharsTitle = this.CardTitle.text.Length;
        RectTransform rect = this.TitleBackObj.GetComponent<RectTransform>();
        float height = rect.rect.height;
        rect.sizeDelta = new Vector2(11.2f * (numCharsTitle + 1), height);
    }

    public void SetCardSide(Card.Side side)
    {
        if (side == Card.Side.Back)
        {
            FrontObj.SetActive(false);
            BackObj.SetActive(true);
            TitleObj.SetActive(false);
            TitleBackObj.SetActive(false);
            LogoObj.SetActive(false);
            DescBackObj.SetActive(false);
            DescObj.SetActive(false);
        }
        else if (side == Card.Side.Front)
        {
            FrontObj.SetActive(true);
            BackObj.SetActive(false);
            TitleObj.SetActive(true);
            TitleBackObj.SetActive(true);
            LogoObj.SetActive(true);
            DescBackObj.SetActive(true);
            DescObj.SetActive(true);
        }
    }

}
