using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
abstract class SupportSkill : Skill
{
    [Space]
    [Header("SupportSkillSettings")]
    [SerializeField]
    protected float percentage;
    [SerializeField]
    protected int counter = 0;
    [SerializeField]
    protected int maxUses;

    public SupportSkill(string name, int power, Affinity affinity, float porcentaje, int maxUses) : base(name, power, affinity)
    {
        this.percentage = porcentaje;
        this.power = 0;
        this.maxUses = maxUses;
    }

    public float Percentage { get => percentage; }

    protected virtual float GetMaxBonus(float baseAttribute)
    {
        return Math.Abs(percentage * baseAttribute * maxUses);
    }
}