using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SupportSkillScriptableObject : SkillScriptableObject
{
    [Space]
    [Header("SupportSkillSettings")]
    public float percentage;
    public int counter = 0;
    public int maxUses;
}