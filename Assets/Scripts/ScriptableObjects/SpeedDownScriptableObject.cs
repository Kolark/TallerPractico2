using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedDown", menuName = "Skills/SupportSkills/SpeedDown")]
public class SpeedDownScriptableObject : SupportSkillScriptableObject
{
    public override Skill getObject()
    {
        return new SpeedDown(this);
    }
}