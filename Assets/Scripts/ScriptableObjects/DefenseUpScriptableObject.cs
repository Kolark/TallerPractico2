using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefenseUp", menuName = "Skills/SupportSkills/DefenseUp")]
public class DefenseUpScriptableObject : SupportSkillScriptableObject
{
    public override Skill getObject()
    {
        return new DefenseUp(this);
    }
}