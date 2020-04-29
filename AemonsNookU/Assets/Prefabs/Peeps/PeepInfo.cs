using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PeepInfo
{
    // 18 total types
    public enum Type
    {
        homeless,
        thief,
        child,
        farmer,
        trader,
        monk,
        nun,
        foreigner,
        elder,
        priest,
        knight,
        witch,
        bard,
        quester,
        wizard,
        bishop,
        lady,
        king
    }

    public enum Sex
    {
        male,
        female
    }

    public static void UpdatePeepType(Peep p, Type t)
    {
        p.Type = t;
        p.Sex = GenerateSex(t);
        p.Fame = GenerateFame(t);
        p.FirstName = GenerateFirstName(p.Sex);
        p.SirName = GenerateSirname(p.Fame);
        p.Stamina = GenerateFatigue(t, p.Sex);
        p.Age = GenerateAge(t);
    }

    public static int GenerateFatigue(Type t, Sex s)
    {
        // todo
        return 250;
    }

    public static int GenerateAge(Type t)
    {
        // todo
        return Random.Range(1, 60);
    }

    public static string GenerateFirstName(Sex s)
    {
        switch (s)
        {
            case Sex.female:
                return GetRandomName(FNAMES_FEMALE);
            case Sex.male:
                return GetRandomName(FNAMES_MALE);
            default:
                return GetRandomName(FNAMES_MALE);
        }
    }
    public static string GenerateSirname(int fame)
    {
        if (fame < 8)
        {
            return GetRandomName(SIRNAMES_COMMON);
        }
        else if (fame >= 8 && fame < 13)
        {
            return GetRandomName(SIRNAMES_MIDDLE);
        }
        else
        {
            return GetRandomName(SIRNAMES_ROYAL);
        }
    }

    public static Sex GenerateSex(Type t)
    {
        // todo
        return Sex.female;
    }


    public static int GenerateFame(Type t)
    {
        switch (t)
        {
            case Type.homeless:
                return 1;
            case Type.thief:
                return 1;
            case Type.child:
                return 2;
            case Type.farmer:
                return 3;
            case Type.trader:
                return 5;
            case Type.monk:
                return 6;
            case Type.nun:
                return 6;
            case Type.foreigner:
                return 7;
            case Type.elder:
                return 7;
            case Type.priest:
                return 9;
            case Type.knight:
                return 12;
            case Type.witch:
                return 12;
            case Type.bard:
                return 13;
            case Type.quester:
                return 15;
            case Type.wizard:
                return 16;
            case Type.bishop:
                return 20;
            case Type.lady:
                return 25;
            case Type.king:
                return 30;
            default:
                return 0;
        }
    }



    public static string GetRandomName(string[] listNames)
    {
        int index = Random.Range(0, listNames.Length);
        return listNames[index];
    }

    public static string[] FNAMES_MALE = { "Merek", "Carac", "Ulric", "Tybalt", "Borin", "Sadon", "Terrowin", "Rowan", "Forthwind", "Fendrel", "Brom", "Hadrian", "Walter", "Earl", "John", "Oliver", "Justice", "Clifton", "Walter", "Roger", "Joseph", "Geoffrey", "William", "Francis", "Simon", "John", "William", "Edmund", "Charles", "Benedict", "Gregory", "Peter", "Henry", "Frederick", "Walter", "Thomas", "Arthur", "Bryce", "Donald", "Letholdus", "Lief", "Barda", "Rulf", "Robin", "Gavin", "Terrin", "Ronald", "Jarin", "Cassius", "Leo", "Cedric", "Gavin", "Peyton", "Josef", "Doran", "Asher", "Quinn", "Zane  ", "Destrian", "Dain", "Falk", "Berinon", "Tristan", "Gorvenal" };
    public static string[] FNAMES_FEMALE = {"Alys", "Ayleth", "Anastas", "Alianor", "Cedany", "Ellyn", "Helen", "Eliose", "Peronell", "Sibyl", "Esme", "Thea", "Jacquelyn", "Amelia", "Gloriana", "Bess", "Catherine", "Anne", "Mary", "Arabella", "Elizabeth", "Hildegard", "Brunhild", "Adelaide", "Alice", "Beatrix", "Cristiana", "Eleanor", "Emeline", "Isabel", "Juliana", "Margaret", "Matilda", "Mirabelle", "Rose", "Helena", "Guinevere", "Isolde", "Maerwynn", "Muriel", "Winifred", "Godiva", "Catrain", "Jasmine", "Josselyn", "Maria", "Victoria", "Gwendolynn", "Janet", "Luanda", "Atheena", "Dimia", "Phrowenia", "Aleida", "Ariana", "Alexia", "Katelyn", "Katrina", "Loreena", "Kaylein", "Seraphina", "Duraina", "Ryia", "Farfelee", "Benevolence", "Brangian", "Elspeth"};
    public static string[] SIRNAMES_COMMON = {"Mason", "Carpenter", "Cheeseman", "Cook", "Fisher", "Fletcher", "Forester", "Shepherd", "Baker", "Wood", "Belcher", "Meeger", "Potter", "Wrinkle", "Plump"};
    public static string[] SIRNAMES_MIDDLE = {"Braun", "Baxter", "Bennett", "Granger", "Hayward", "Lister", "Mannering", "Sawyer", "Ward", "Webb", "Wright", "Williams", "McCloy", "Duncan"};
    public static string[] SIRNAMES_ROYAL = {"Nook", "Bonaparte", "Valentine", "Wales", "Windsor", "Hanover", "Grimm"};
    public static string[] TITLES_MALE = {"Mountain", "Rock", "Quick and Nimble", "Rich in Wisdom", "Swift as the Wind", "Slayer of Dragons"};
    public static string[] TITLES_FEMALE = {"Bringer of Joy", "Fairest of Ladies", "Envy of the North", "Delicate as Rain", "Blossom of Peace"};

}
