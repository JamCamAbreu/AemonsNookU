using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemInfo
{
    public enum Type
    {
        cloth,
        copper,
        meat,
        dairy,
        spice,
        horses,
        silver,
        mead,
        gold
    }

    public static string GetItemDescription(Type t)
    {
        switch (t)
        {
            case Type.cloth:
                return "Cloth";

            case Type.copper:
                return "Copper";

            case Type.meat:
                return "Meat";

            case Type.dairy:
                return "Dairy";

            case Type.spice:
                return "Spice";

            case Type.horses:
                return "Horses";

            case Type.silver:
                return "Silver";

            case Type.mead:
                return "Mead";

            case Type.gold:
                return "Gold";

            default:
                return "ErrorType";
        }
    }

    public static string GetItemName(Type t)
    {
        switch (t)
        {
            case Type.cloth:
                return "Cloth";

            case Type.copper:
                return "Copper";

            case Type.meat:
                return "Meat";

            case Type.dairy:
                return "Dairy";

            case Type.spice:
                return "Spice";

            case Type.horses:
                return "Horses";

            case Type.silver:
                return "Silver";

            case Type.mead:
                return "Mead";

            case Type.gold:
                return "Gold";

            default:
                return "ErrorType";
        }
    }


}
