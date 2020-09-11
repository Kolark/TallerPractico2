using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AttackSkill : Skill
{
    System.Random rnd = new System.Random();

    public AttackSkill(SkillScriptableObject skill) : base(skill)
    {
        if (skill.power <= 0 || skill.power > 10)
        {
            this.power = rnd.Next(1, 11);
        }
    }

    public override void DoSkill(Critter currentCritter, Critter enemyCritter)
    {
        float damageValue = (power + currentCritter.Attack) * Stats.Matrix[(int)(affinity), (int)(enemyCritter.Affinity)];
        enemyCritter.GetDamage(damageValue);
        //Console.WriteLine(damageValue + " damage");
    }
}
