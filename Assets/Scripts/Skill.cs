using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    [Header("Skill Settings")]
    [SerializeField]
    protected string name;
    [SerializeField]
    protected int power;
    [SerializeField]
    protected Affinity affinity;
    
    public Skill(string name, int power, Affinity affinity)
    {
        this.name = name;
        this.power = power;
        this.affinity = affinity;
    }

    public string Name { get => name; }
    public int Power { get => power; }
    public Affinity Affinity { get => affinity; }

    public abstract void DoSkill(Critter currentCritter, Critter enemyCritter);
}
