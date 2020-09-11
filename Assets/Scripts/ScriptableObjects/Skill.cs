using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{

    protected string skillName;
    protected int power;
    protected Affinity affinity;
    
    public Skill(SkillScriptableObject skill)
    {
        this.skillName = skill.skillName;
        this.power = skill.power;
        this.affinity = skill.affinity;
    }

    public string Name { get => skillName; }
    public int Power { get => power; }
    public Affinity Affinity { get => affinity; }

    public abstract void DoSkill(Critter currentCritter, Critter enemyCritter);
}


public abstract class SkillScriptableObject : ScriptableObject
{
    [Header("Skill Settings")]
    public string skillName;
    public int power;
    public Affinity affinity;

    public abstract Skill getObject();
}