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
            currentCritter.bonusDefense += (int)(currentCritter.BaseDefense * percentage);
        }
        else
        {
            //Console.WriteLine("Can't use a defUp skill of the same type more than three times in the same critter, you lose your turn!");
        }
    }
}
[CreateAssetMenu(fileName = "DefenseUp", menuName = "Skills/SupportSkills/DefenseUp")]
public class DefenseUpScriptableObject : SupportSkillScriptableObject
{
    public override Skill getObject()
    {
        return new DefenseUp(this);
    }
}