using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackSkill", menuName = "Skills/AttackSkills/AttackSkill")]
class AttackSkill : Skill
{
    System.Random rnd = new System.Random();
    public AttackSkill(string name, int power, Affinity affinity) : base(name, power, affinity)
    {
        if (power <= 0 || power > 10)
        {
            //Console.WriteLine("Poder seleccionado invalido, se asignará un valor aleatorio entre 1 y 10");
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