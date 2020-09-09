using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "new Critter", menuName = "Critter")]
public class Critter:ScriptableObject
{
    public Sprite img;
    [SerializeField]
    private string name;
    [SerializeField]
    private int baseAttack;
    [SerializeField]
    private int baseDefense;
    [SerializeField]
    private int baseSpeed;
    [SerializeField]
    private float hp;

    [HideInInspector]
    public float bonusAttack;
    [HideInInspector]
    public float bonusDefense;
    [HideInInspector]
    public float bonusSpeed;
    [SerializeField]
    private List<Skill> moveSet;
    [SerializeField]
    Affinity affinity;


    System.Random rnd = new System.Random();

    public Critter(string name, int baseAttack, int baseDefense, int baseSpeed, float hp, Affinity affinity, List<Skill> skills)
    {
        this.baseAttack = (baseAttack < 10 || baseAttack > 100 ? rnd.Next(1, 101) : baseAttack);
        this.baseDefense = (baseDefense < 10 || baseDefense > 100 ? rnd.Next(1, 101) : baseDefense);
        this.baseSpeed = (baseSpeed < 1 || baseSpeed > 50 ? rnd.Next(1, 51) : baseSpeed);
        this.name = name;
        this.hp = hp;
        this.affinity = affinity;
        
        if (skills.Count <= 3)
        {
            moveSet = skills;
        }
        else
        {
            moveSet = new List<Skill>();
            for (int i = 0; i < 3; i++)
            {
                moveSet.Add(skills[i]);
            }
        }

    }

    public void GetDamage(float damageTaken)
    {
        hp -= damageTaken;
        if (hp < 0) hp = 0;
    }


    public string Name { get => name; }
    public float BaseAttack { get => baseAttack; }
    public float BaseDefense { get => baseDefense; }
    public float BaseSpeed { get => baseSpeed; }
    public float Attack { get => baseAttack + bonusAttack; }
    public float Defense { get => baseDefense + bonusDefense; }
    public float Speed { get => baseSpeed + bonusSpeed; }

    public float Hp { get => hp; }
    public Affinity Affinity { get => affinity; }
    public List<Skill> MoveSet { get => moveSet; }
}