using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIFacade : MonoBehaviour
{
    RectTransform rect;
    [SerializeField]
    UserUI userInfo;

    UserUI[] userUIs;
    [SerializeField]
    SpritePool SpritePool;
    [SerializeField]
    ButtonPool buttonPool;

    public void Init()
    {
        rect = GetComponent<RectTransform>();
        userUIs = new UserUI[2];
        for (int i = 0; i < 2; i++)
        {
            userUIs[i] = Instantiate(userInfo, rect);
        }
        SpritePool.initpool();
        buttonPool.initPool();
    }
    public void UpdateUserUI(User user, int i)
    {
        if (user is Player)
        {
            userUIs[i].INIT(user as Player);
        }
        else if(user is EnemyBot)
        {
            userUIs[i].INIT(user as EnemyBot);
        }
    }



    public void replenishCritter(Critter critter,int i)
    {
        userUIs[i].NextCritter();
        userUIs[i].SetCurrentCritterName(critter);

    }

    public void RecycleCritterSprite(int i)
    {
        userUIs[i].RecycleCritterIMG();
    }


    #region UpdateCurrentDisplayingCritter
    /// <summary>
    /// actualiza el estado de ambos critters
    /// </summary>
    /// <param name="critters"></param>
    public void UpdateCrittersState(Critter[] critters)
    {
        for (int i = 0; i < userUIs.Length; i++)
        {
            userUIs[i].UpdateCurrentCritter(critters[i]);
        }
    }
    #endregion



    #region EnableAndDisable
    public void EnableUserButtons(int i)
    {
        userUIs[i].EnableButtons();
    }
    public void DisableUserButtons(int i)
    {
        userUIs[i].DisableButtons();
    }
    #endregion
}
//[Header("CurrentCritter")]
//[SerializeField]
//RectTransform currentCritter;
//[SerializeField]
//Slider hp;
//[Space]
//[Header("other Critters")]
//[SerializeField]
//RectTransform ButtonHolder;
//[SerializeField]
//RectTransform SpritesHolder;
//[Header("Text")]
//[SerializeField]
//TextMesh text;

//List<SkillButton> skillButtons = new List<SkillButton>();
//List<Image> critterImgs = new List<Image>();


//public void SET(User player)
//{
//    //Recicla
//    if (skillButtons.Count != 0)
//    {
//        for (int i = skillButtons.Count; i > 0; i--)
//        {
//            ButtonPool.Instance.Recycle(skillButtons[i]);
//        }
//    }
//    if (critterImgs.Count != 0)
//    {
//        for (int i = critterImgs.Count; i > 0; i--)
//        {
//            SpritePool.Instance.Recycle(critterImgs[i]);
//        }
//    }


//    //Luego añade
//    Debug.Log("Size: " + player.critters[0].MoveSet.Count);
//    for (int i = 0; i < player.critters[0].MoveSet.Count; i++)
//    {
//        //Obtengo los botones necesarios
//        skillButtons.Add(ButtonPool.Instance.GetObject());
//        //
//        //Los hago hijo del buttonholder
//        skillButtons[i].SetNumber(i);
//        skillButtons[i].GetComponent<RectTransform>().SetParent(ButtonHolder, false);
//        skillButtons[i].OnButtonPressed += player.ExecuteComand;
//        skillButtons[i].SetSkillInfo(player.critters[0].MoveSet[i]);
//    }


//    for (int i = 0; i < player.critters.Count; i++)
//    {
//        critterImgs.Add(SpritePool.Instance.GetObject());
//        //
//        //Los hago hijo del buttonholder
//        critterImgs[i].GetComponent<RectTransform>().SetParent(SpritesHolder, false);

//        critterImgs[i].sprite = player.critters[i].img;
//    }
//    critterImgs[0].GetComponent<RectTransform>().SetParent(currentCritter, false);


//}