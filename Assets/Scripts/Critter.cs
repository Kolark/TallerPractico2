using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Critter
{
    public Sprite img;
    private string crittername;
    private int baseAttack;
    private int baseDefense;
    private int baseSpeed;
    private float baseHP;

    private float currentHP;
    public float bonusAttack = 0;
    public float bonusDefense = 0;
    public float bonusSpeed = 0;

    private List<Skill> moveSet;

    Affinity affinity;


    System.Random rnd = new System.Random();

    public Critter(CritterScriptableObject critter)
    {

        this.img = critter.img;
        this.crittername = critter.crittername;
        this.baseAttack = (critter.baseAttack < 10 || critter.baseAttack > 100 ? rnd.Next(1, 101) : critter.baseAttack);
        this.baseDefense = (critter.baseDefense < 10 || critter.baseDefense > 100 ? rnd.Next(1, 101) : critter.baseDefense);
        this.baseSpeed = (critter.baseSpeed < 1 || critter.baseSpeed > 50 ? rnd.Next(1, 51) : critter.baseSpeed);
        this.baseHP = critter.baseHP;
        this.currentHP = baseHP;

        //moveset
        moveSet = new List<Skill>();
        for (int i = 0; i < critter.moveSet.Count; i++)
        {
            moveSet.Add(critter.moveSet[i].getObject());
        }
        this.affinity = critter.affinity;
    }

    public void GetDamage(float damageTaken)
    {
        currentHP -= damageTaken;
        if (currentHP < 0) currentHP = 0;
    }

    public string Name { get => crittername; }
    public float BaseAttack { get => baseAttack; }
    public float BaseDefense { get => baseDefense; }
    public float BaseSpeed { get => baseSpeed; }
    public float Attack { get => baseAttack + bonusAttack; }
    public float Defense { get => baseDefense + bonusDefense; }
    public float Speed { get => baseSpeed + bonusSpeed; }

    public float CurrentHp { get => currentHP; }
    public float BaseHP { get => baseHP; }
    public Affinity Affinity { get => affinity; }
    public List<Skill> MoveSet { get => moveSet; }
}


[CreateAssetMenu(fileName = "new Critter", menuName = "Critter")]
public class CritterScriptableObject: ScriptableObject
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


//public void INIT()
//{
//    baseAttack = (baseAttack < 10 || baseAttack > 100 ? rnd.Next(1, 101) : baseAttack);
//    baseDefense = (baseDefense < 10 || baseDefense > 100 ? rnd.Next(1, 101) : baseDefense);
//    baseSpeed = (baseSpeed < 1 || baseSpeed > 50 ? rnd.Next(1, 51) : baseSpeed);
//    currentHP = baseHP;


//    if (moveSet.Count > 3)
//    {
//        List<Skill> temp = new List<Skill>();
//        for (int i = 0; i < 3; i++)
//        {
//            temp.Add(moveSet[i]);
//        }
//        moveSet = temp;
//    }