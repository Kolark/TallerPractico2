using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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


    private static UIFacade instance;
    public static UIFacade Instance { get => instance; }

    public void Init()
    {
        rect = GetComponent<RectTransform>();
        #region singleton
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        #endregion
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

    [Header("Texts")]
    [SerializeField]
    TextMeshProUGUI playerResponsible;
    [SerializeField]
    TextMeshProUGUI crittertxt;
    [SerializeField]
    TextMeshProUGUI nextTurn;


    public void SetText(int n)
    {
        playerResponsible.text = "El jugador " + (n + 1).ToString() + " hizo lo siguiente: ";
        nextTurn.text = "Ahora es turno del jugador " + (1 - n + 1).ToString();
    }
    public void SkillEffectText(string txt)
    {
        crittertxt.text = txt;
    }
}
