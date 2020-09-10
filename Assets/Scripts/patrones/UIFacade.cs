using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIFacade : MonoBehaviour
{
    [Header("CurrentCritter")]
    [SerializeField]
    RectTransform currentCritter;
    [SerializeField]
    Slider hp;
    [Space]
    [Header("other Critters")]
    [SerializeField]
    RectTransform ButtonHolder;
    [SerializeField]
    RectTransform SpritesHolder;
    [Header("Text")]
    [SerializeField]
    TextMesh text;

    List<SkillButton> skillButtons = new List<SkillButton>();
    List<Image> critterImgs = new List<Image>();


    public void SET(Player player)
    {
        //Recicla
        if (skillButtons.Count != 0)
        {
            for (int i = skillButtons.Count; i > 0; i--)
            {
                ButtonPool.Instance.Recycle(skillButtons[i]);
            }
        }
        if (critterImgs.Count != 0)
        {
            for (int i = critterImgs.Count; i > 0; i--)
            {
                SpritePool.Instance.Recycle(critterImgs[i]);
            }
        }


        //Luego añade
        Debug.Log("Size: " + player.critters.Peek().MoveSet.Count);
        for (int i = 0; i < player.critters.Peek().MoveSet.Count; i++)
        {
            //Obtengo los botones necesarios
            skillButtons.Add(ButtonPool.Instance.GetObject());
            //
            //Los hago hijo del buttonholder
            skillButtons[i].GetComponent<RectTransform>().SetParent(ButtonHolder, false);
            skillButtons[i].OnButtonPressed += player.ExecuteComand;
            skillButtons[i].SetSkillInfo(player.critters.Peek().MoveSet[i]);
        }


        for (int i = 0; i < player.critters.Count; i++)
        {
            critterImgs.Add(SpritePool.Instance.GetObject());
            //
            //Los hago hijo del buttonholder
            critterImgs[i].GetComponent<RectTransform>().SetParent(SpritesHolder, false);

            critterImgs[i].sprite = player.crittersToADD[i].img;
        }
        critterImgs[0].GetComponent<RectTransform>().SetParent(currentCritter, false);


    }

    public void UpdateCurrentCritter(Critter critter)
    {
        //Actualiza stats del critter con el que esta peleando en ese momento
    }
    public void UpdateCritters(Player player)
    {
        //Actualiza los critters que tiene
    }
}
