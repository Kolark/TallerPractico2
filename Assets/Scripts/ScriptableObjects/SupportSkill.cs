using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
abstract class SupportSkill : Skill
{
    protected float percentage;
    protected int counter = 0;
    protected int maxUses;

    public SupportSkill(SupportSkillScriptableObject skill) : base(skill)
    {
        this.percentage = skill.percentage;
        this.power = 0;
        this.maxUses = skill.maxUses;
    }

    public float Percentage { get => percentage; }

    protected virtual float GetMaxBonus(float baseAttribute)
    {
        return Math.Abs(percentage * baseAttribute * maxUses);
    }
}

