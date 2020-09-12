﻿using System.Collections;
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
            int amount = (int)(currentCritter.BaseAttack * percentage);
            currentCritter.bonusAttack += amount;

            string msg = currentCritter.Name + " Se subio el daño " + (percentage*100).ToString() + "%";
            UIFacade.Instance.SkillEffectText(msg);
        }
        else
        {
            //Console.WriteLine("Can't use a AtkUp skill of the same type more than three times in the same critter, you lose your turn!");
            UIFacade.Instance.SkillEffectText("Alcanzo el limite de usos para la habilidad del AttackUp");
        }
    }
}
