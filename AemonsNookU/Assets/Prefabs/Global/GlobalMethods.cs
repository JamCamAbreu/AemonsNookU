﻿using System;
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


    public static Vector2 ConstantEase(Vector2 curVal, Vector2 targetVal, int dividend)
    {
        try
        {
            Vector2 test = targetVal - curVal;
            test = test / dividend;
        }
        catch (Exception e)
        {

        }

        return (Vector2)(curVal + ((targetVal - curVal) / dividend));
    }


    // Note: Does not support negative values:
    public static Quaternion Ease(Quaternion curVal, Quaternion targetVal, float speed)
    {
        // a * b                          == (a + b)
        // a * inverse(b)                 == (a - b)
        // slerp(a, speed)                == (a * speed) 

        Quaternion first = targetVal * Quaternion.Inverse(curVal);
        Quaternion second = Quaternion.Slerp(Quaternion.identity, first, speed);
        return (Quaternion)(curVal * second);
    }

    // Supports negative values but doesn't do as good as above overall
    //public static Quaternion Ease(Quaternion curVal, Quaternion targetVal, float speed)
    //{
    //    float newX = Ease(curVal.eulerAngles.x, targetVal.eulerAngles.x, speed);
    //    float newY = Ease(curVal.eulerAngles.y, targetVal.eulerAngles.y, speed);
    //    float newZ = Ease(curVal.eulerAngles.z, targetVal.eulerAngles.z, speed);
    //    return Quaternion.Euler(newX, newY, newZ);
    //}


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
