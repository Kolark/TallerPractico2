using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonPool : MonoBehaviour, IPool<SkillButton>
{
    RectTransform rectTransform;
    private static ButtonPool instance;
    public static ButtonPool Instance { get => instance; }

    [SerializeField]
    SkillButton pooleable;

    private List<SkillButton> skillButtons = new List<SkillButton>();
    public List<SkillButton> SkillButtons { get => skillButtons;}

    public int PoolSize;

    private void Awake()
    {
        #region singleton
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        #endregion
        rectTransform = GetComponent<RectTransform>();
        PoolSize = 3;
        Fill();
    }


    public void Fill()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            SkillButtons.Add(Instantiate(pooleable, this.transform));
            SkillButtons[i].SetNumber(i);
        }
    }

    public SkillButton GetObject()
    {
        SkillButton skillButton = skillButtons[0];
        skillButtons.RemoveAt(0);
        return skillButton;
    }

    public void Recycle(SkillButton poolObject)
    {
        SkillButtons.Insert(0, poolObject);
        poolObject.GetComponent<RectTransform>().SetParent(rectTransform,false);
    }
}
