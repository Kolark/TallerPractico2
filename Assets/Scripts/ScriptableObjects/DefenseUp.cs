using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class DefenseUp : SupportSkill
{

    public DefenseUp(DefenseUpScriptableObject skill) : base(skill)
    {

    }
    public override void DoSkill(Critter currentCritter, Critter enemyCritter)
    {
        if (currentCritter.bonusDefense < GetMaxBonus(currentCritter.BaseDefense))
        {
            //Console.WriteLine("defense Up");
            int amount = (int)(currentCritter.BaseDefense * percentage);
            currentCritter.bonusDefense += amount;

            string msg = currentCritter.Name + " Se subio la defense en un " + (percentage * 100).ToString() + "%";
            UIFacade.Instance.SkillEffectText(msg);
        }
        else
        {
            //Console.WriteLine("Can't use a defUp skill of the same type more than three times in the same critter, you lose your turn!");
            UIFacade.Instance.SkillEffectText("Alcanzo el limite de usos para la habilidad del DefenseUp");
        }
    }
}
