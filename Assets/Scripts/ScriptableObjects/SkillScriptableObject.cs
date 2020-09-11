using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillScriptableObject : ScriptableObject
{
    [Header("Skill Settings")]
    public string skillName;
    public int power;
    public Affinity affinity;

    public abstract Skill getObject();
}