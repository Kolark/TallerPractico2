using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Critter", menuName = "Critter")]
public class CritterScriptableObject : ScriptableObject
{
    public Sprite img;
    public string crittername;
    public int baseAttack;
    public int baseDefense;
    public int baseSpeed;
    public float baseHP;
    public List<SkillScriptableObject> moveSet;
    public Affinity affinity;

    public Critter getObject()
    {
        return new Critter(this);
    }
}