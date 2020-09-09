using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stats
{
    private static float[,] matrix = {
            
          //| Da |Li  |Fi  |Wa  | Wi | Ea |
            {0.5f,2.0f,1.0f,1.0f,1.0f,1.0f}, //Dark
            {2.0f,0.5f,1.0f,1.0f,1.0f,1.0f}, //Light
            {1.0f,1.0f,0.5f,2.0f,1.0f,0.0f}, //Fire
            {1.0f,1.0f,0.5f,0.5f,2.0f,1.0f}, //Water
            {1.0f,1.0f,1.0f,0.5f,0.5f,0.5f}, //Wind
            {1.0f,1.0f,1.0f,1.0f,2.0f,0.5f}  //Earth
        };
    public static float[,] Matrix { get => matrix; }
}
public enum Affinity
{
    Dark, Light, Fire, Water, Wind, Earth
}