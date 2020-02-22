using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMethods
{
    public static float Ease(float curVal, float targetVal, float speed)
    {
        return curVal + (targetVal - curVal) * speed;
    }

    public static int Ease(int curVal, int targetVal, float speed)
    {
        return (int)(curVal + (targetVal - curVal) * speed);
    }

    public static double Ease(double curVal, double targetVal, float speed)
    {
        return (double)(curVal + (targetVal - curVal) * speed);
    }

    public static Vector2 Ease(Vector2 curVal, Vector2 targetVal, float speed)
    {
        return (Vector2)(curVal + (targetVal - curVal) * speed);
    }

    public static Vector3 Ease(Vector3 curVal, Vector3 targetVal, float speed)
    {
        return (Vector3)(curVal + (targetVal - curVal) * speed);
    }

    public static void Rot90(BuildingSelectionSquare input)
    {
        int preX = input.relativeX;
        int preY = input.relativeY;

        input.relativeX = -preY;
        input.relativeY = preX;
    }

    public static Vector2 Rot90(Vector2 input)
    {
        float preX = input.x;
        float preY = input.y;

        return new Vector2(-preY, preX);
    }

}
