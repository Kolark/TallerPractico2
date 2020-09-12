using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SpeedDown : SupportSkill
{
    public SpeedDown(SpeedDownScriptableObject skill) : base(skill)
    {

    }

    public override void DoSkill(Critter currentCritter, Critter enemyCritter)
    {
        if (System.Math.Abs(enemyCritter.bonusSpeed) < GetMaxBonus(enemyCritter.BaseSpeed))
        {
            //Console.WriteLine("speed Down");
            int amount = (int)(enemyCritter.BaseSpeed * percentage);
            enemyCritter.bonusSpeed -= (int)(enemyCritter.BaseSpeed * percentage);

            string msg = currentCritter.Name + " Lowered the speed by " + (percentage * 100).ToString() + "% to " + enemyCritter.Name;
            UIFacade.Instance.SkillEffectText(msg);
        }
        else
        {
            //Console.WriteLine("Can't use a sPdown skill of the same type more than three times on the same critter, you lose your turn!");
            UIFacade.Instance.SkillEffectText(currentCritter.Name +" Reached the limit uses for speedDown");
        }
    }
}
