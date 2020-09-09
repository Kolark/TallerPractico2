using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DefenseUp", menuName = "Skills/SupportSkills/DefenseUp")]
class DefenseUp : SupportSkill
{
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
    public DefenseUp(string name, int power, Affinity affinity, float porcentaje, int maxCounter) : base(name, power, affinity, porcentaje, maxCounter)
    {
    }
}