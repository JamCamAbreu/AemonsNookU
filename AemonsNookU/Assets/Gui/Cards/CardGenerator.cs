using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;

public class CardGenerator : MonoBehaviour
{
    public CardDeck deck;
    public CardHand hand;
    public CardDiscard discard;
    public World world;


    #region BuildingSelectionCards 
    public C_Building buildingCardPrefab;
    public BuildingSelection buildingSelectionPrefab;
    public BuildingSelectionSquare squarePrefab;

    public Building archeryAsset;
    public Building bathAsset;
    public Building blacksmithAsset;
    public Building fishBoothAsset;
    public Building gemsBoothAsset;
    public Building produceBoothAsset;
    public Building seedsBoothAsset;
    public Building butcherAsset;
    public Building chapelAsset;
    public Building clothAsset;
    public Building innAsset;
    public Building scribeAsset;
    public Building stablesAsset;
    public Building tannerAsset;
    public Building tavernAsset;

    #endregion


    public enum CardType
    {
        BuildArchery,
        BuildBath,
        BuildBlacksmith,
        BuildBoothFish,
        BuildBoothGems,
        BuildBoothProduce,
        BuildBoothSeeds,
        BuildButcher,
        BuildChapel,
        BuildCloth,
        BuildInn,
        BuildScribe,
        BuildStables,
        BuildTanner,
        BuildTavern
    }


    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DebugKeys();
    }

    public bool IsBuildingCardType(CardType type)
    {
        if (type == CardType.BuildArchery || 
            type == CardType.BuildBath ||
            type == CardType.BuildBlacksmith ||
            type == CardType.BuildBoothFish ||
            type == CardType.BuildBoothGems ||
            type == CardType.BuildBoothProduce ||
            type == CardType.BuildBoothSeeds ||
            type == CardType.BuildButcher ||
            type == CardType.BuildChapel ||
            type == CardType.BuildCloth ||
            type == CardType.BuildInn ||
            type == CardType.BuildScribe ||
            type == CardType.BuildStables ||
            type == CardType.BuildTanner ||
            type == CardType.BuildTavern)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public bool IsBadCardType(CardType type)
    {
        return false;
    }

    public Card GenerateBuildingCard(CardType type)
    {
        Card returnCard = null;
        Building buildingPrefab = null;
        BuildingInfo.Type buildingType = BuildingInfo.Type.ARCHERY;

        switch (type)
        {
            case CardType.BuildArchery:
                buildingPrefab = archeryAsset;
                buildingType = BuildingInfo.Type.ARCHERY;
                break;

            case CardType.BuildBath:
                buildingPrefab = bathAsset;
                buildingType = BuildingInfo.Type.BATH;
                break;

            case CardType.BuildBlacksmith:
                buildingPrefab = blacksmithAsset;
                buildingType = BuildingInfo.Type.BLACKSMITH;
                break;

            case CardType.BuildBoothFish:
                buildingPrefab = fishBoothAsset;
                buildingType = BuildingInfo.Type.BOOTH_FISH;
                break;

            case CardType.BuildBoothGems:
                buildingPrefab = gemsBoothAsset;
                buildingType = BuildingInfo.Type.BOOTH_GEMS;
                break;

            case CardType.BuildBoothProduce:
                buildingPrefab = produceBoothAsset;
                buildingType = BuildingInfo.Type.BOOTH_PRODUCE;
                break;

            case CardType.BuildBoothSeeds:
                buildingPrefab = seedsBoothAsset;
                buildingType = BuildingInfo.Type.BOOTH_SEEDS;
                break;

            case CardType.BuildButcher:
                buildingPrefab = butcherAsset;
                buildingType = BuildingInfo.Type.BUTCHER;
                break;

            case CardType.BuildChapel:
                buildingPrefab = chapelAsset;
                buildingType = BuildingInfo.Type.CHAPEL;
                break;

            case CardType.BuildCloth:
                buildingPrefab = clothAsset;
                buildingType = BuildingInfo.Type.CLOTH;
                break;

            case CardType.BuildInn:
                buildingPrefab = innAsset;
                buildingType = BuildingInfo.Type.INN;
                break;

            case CardType.BuildScribe:
                buildingPrefab = scribeAsset;
                buildingType = BuildingInfo.Type.SCRIBE;
                break;

            case CardType.BuildStables:
                buildingPrefab = stablesAsset;
                buildingType = BuildingInfo.Type.STABLES;
                break;

            case CardType.BuildTanner:
                buildingPrefab = tannerAsset;
                buildingType = BuildingInfo.Type.TANNER;
                break;

            case CardType.BuildTavern:
                buildingPrefab = tavernAsset;
                buildingType = BuildingInfo.Type.TAVERN;
                break;

            default:
                break;
        }

        if (buildingPrefab != null)
        {
            C_Building bCard = Instantiate(buildingCardPrefab);
            bCard.world = this.world;
            bCard.buildingSelectionPrefab = this.buildingSelectionPrefab;
            bCard.buildingPrefab = buildingPrefab;
            bCard.buildingType = buildingType;
            bCard.cardUI.CardLogo.sprite = buildingPrefab.Icon;
            bCard.cardUI.CardTitle.text = buildingPrefab.Name;
            bCard.cardUI.CardDescription.text = buildingPrefab.Description;
            returnCard = bCard;
        }

        Assert.IsNotNull(returnCard);
        return returnCard;
    }

    public Color RetrieveCardTypeColor(CardType type)
    {
        if (IsBuildingCardType(type))
        {
            return new UnityEngine.Color(47f/255f, 221f/255f, 41f/255f, 85f/255f); // green
        }
        else if (IsBadCardType(type))
        {
            return Color.red;
        }
        else
        {
            return Color.cyan;
        }
    }

    public Card Generate(CardType type)
    {
        Card returnCard = null;

        if (IsBuildingCardType(type))
        {
            returnCard = GenerateBuildingCard(type);
        }


        else
        {
            switch (type)
            {
                //case CardType.BuildArchery:
                //    break;

                default:
                    break;
            }
        }
            
        if (returnCard != null)
        {
            returnCard.cardUI.SetTitleBackWidth();
            returnCard.cardUI.SetCardTitleBackColor(this.RetrieveCardTypeColor(type));
        }
        
        Assert.IsNotNull(returnCard);
        return returnCard;
    }


    public void DebugKeys()
    {

        if (Input.GetKeyDown("1"))
        {

            int min = 0;
            int max = (int)CardType.BuildTavern;
            int typeRoll = UnityEngine.Random.Range(min, max);

            Card debugCard = Generate((CardType)typeRoll);
            Vector2 spawnPos = new Vector2(deck.transform.position.x - 20f, deck.transform.position.y - 50f);
            debugCard.transform.position = spawnPos;
            debugCard.transform.rotation = Quaternion.Euler(0, 0, -40);
            debugCard.TargetRot = Quaternion.Euler(0, 0, 0);
            debugCard.deck = this.deck;
            debugCard.hand = this.hand;
            debugCard.discard = this.discard;
            debugCard.state = Card.CardState.deck;
            debugCard.SetCardSide(Card.Side.Back);

            deck.notificationCanvas.AddNotification(Notification.Type.userAction, $"Adding card to deck.");
            deck.AddCard(debugCard, true, true);
        }

    }

}
