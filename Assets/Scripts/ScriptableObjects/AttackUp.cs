using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AttackUp : SupportSkill
{

    public AttackUp(AttackUpScriptableObject skill) : base(skill)
    {

    }

    public override void DoSkill(Critter currentCritter, Critter enemyCritter)
    {
        if (currentCritter.bonusAttack < GetMaxBonus(currentCritter.BaseAttack))
        {
            //Console.WriteLine("attack Up");
            currentCritter.bonusAttack += (int)(currentCritter.BaseAttack * percentage);
        }
        else
        {
            //Console.WriteLine("Can't use a AtkUp skill of the same type more than three times in the same critter, you lose your turn!");
        }
    }
}
