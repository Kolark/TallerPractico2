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
        SpritePool.InitPool();
        buttonPool.InitPool();
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



    public void replenishCritter(int i)
    {
        userUIs[i].NextCritter();
        //userUIs[i].SetCurrentCritterName(critter);

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
