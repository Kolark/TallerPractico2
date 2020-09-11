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
            enemyCritter.bonusSpeed += (int)(enemyCritter.BaseSpeed * percentage);
        }
        else
        {
            //Console.WriteLine("Can't use a sPdown skill of the same type more than three times on the same critter, you lose your turn!");
        }
    }
}
[CreateAssetMenu(fileName = "SpeedDown", menuName = "Skills/SupportSkills/SpeedDown")]
public class SpeedDownScriptableObject : SupportSkillScriptableObject
{
    public override Skill getObject()
    {
        return new SpeedDown(this);
    }
}