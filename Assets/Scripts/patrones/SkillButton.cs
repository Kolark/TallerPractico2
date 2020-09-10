using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class SkillButton : MonoBehaviour
{

    public Action<int> OnButtonPressed;
    int number;
    
     TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void Notify()
    {
        OnButtonPressed(number);
    }

    public void SetNumber(int n)
    {
        number = n;
    }

    public void SetSkillInfo(Skill skill)
    {
        text.text = skill.Name;
    }
}
