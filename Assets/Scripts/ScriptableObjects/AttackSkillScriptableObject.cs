using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackSkill", menuName = "Skills/AttackSkills/AttackSkill")]
public class AttackSkillScriptableObject : SkillScriptableObject
{
    public override Skill getObject()
    {
        return new AttackSkill(this);
    }
}