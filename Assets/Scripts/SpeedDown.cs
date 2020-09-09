using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SpeedDown", menuName = "Skills/SupportSkills/SpeedDown")]
class SpeedDown : SupportSkill
{
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
    public SpeedDown(string name, int power, Affinity affinity, float porcentaje, int maxCounter) : base(name, power, affinity, porcentaje, maxCounter)
    {
    }
}