using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attackup", menuName = "Skills/SupportSkills/Attackup")]
public class AttackUpScriptableObject : SupportSkillScriptableObject
{
    public override Skill getObject()
    {
        return new AttackUp(this);
    }
}