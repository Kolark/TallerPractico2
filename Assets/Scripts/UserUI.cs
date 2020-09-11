using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UserUI : MonoBehaviour
{

    [Header("CurrentCritter")]
    [SerializeField]
    RectTransform currentCritter;
    [SerializeField]
    Slider hp;
    [SerializeField]
    TextMeshProUGUI critterName;
    [Space]
    [Header("other Critters")]
    [SerializeField]
    RectTransform ButtonHolder;
    [SerializeField]
    RectTransform SpritesHolder;
    [Header("Texts")]
    [SerializeField]
    TextMeshProUGUI hptext;
    [SerializeField]
    TextMeshProUGUI attack;
    [SerializeField]
    TextMeshProUGUI defense;
    [SerializeField]
    TextMeshProUGUI speed;
    public RectTransform SPRITEHOLDER { get => SpritesHolder;}
    List<SkillButton> skillButtons = new List<SkillButton>();
    List<Image> critterImgs = new List<Image>();

    bool init = false;

    public void INIT(Player user)
    {
        if (!init)
        {
            initSprites(user);
            init = true;
        }
        initButtons(user);

    }
    public void INIT(EnemyBot bot)
    {
        if (!init)
        {
            initSprites(bot);
            init = true;
        }

    }

    void initSprites(User user)
    {
        SetSprites(user);
        NextCritter();
        SetCurrentCritterName(user.fightingCritters.Peek());
    }
    public void initButtons(Player player)
    {
        RecycleButtons();
        SetButtons(player);
    }


    ///Esta región es para todo lo relacionado a la lista de critters
    #region Sprites 


    ///Se encarga de obtener las imagenes del pool de images(lienzos), luego los pinta con los critters del jugador.
    ///
    public void SetSprites(User user)
    {
        for (int i = 0; i < user.fightingCritters.Count; i++)
        {
            critterImgs.Add(SpritePool.Instance.GetObject()); //Obtengo las imagenes donde luego pintare los critter //1.
            ReceiveImage(critterImgs[i]); //Esas imagenes las hago como hijo de mi grid. //2.
            critterImgs[i].sprite = user.fightingCritters.ToArray()[i].img; //3. Las pinto con los critters
        }
    }
    /// <summary>
    /// Lo vuelve hijo para que automaticamente se ponga en el grid
    /// </summary>
    /// <param name="image"></param>
    public void ReceiveImage(Image image)
    {
        image.GetComponent<RectTransform>().SetParent(SpritesHolder, false);
    }

    public void NextCritter()
    {
        critterImgs[0].GetComponent<RectTransform>().SetParent(currentCritter, false);
    }

    public void RecycleCritterIMG()
    {
        Image imgToRecycle = critterImgs[0];
        critterImgs.RemoveAt(0);

        SpritePool.Instance.Recycle(imgToRecycle);
    }
    #endregion
    public void SetCurrentCritterName(Critter critter)
    {
        critterName.text = critter.Name;
    }
    #region Buttons
    public void SetButtons(User user)
    {
        for (int i = 0; i < user.fightingCritters.Peek().MoveSet.Count; i++)
        {
            skillButtons.Add(ButtonPool.Instance.GetObject()); //Pide prestado los botones
            skillButtons[i].SetNumber(i); //Les agrega un identificador
            skillButtons[i].GetComponent<RectTransform>().SetParent(ButtonHolder, false);// Los hago hijos del buttonholder
            skillButtons[i].OnButtonPressed += user.ExecuteComand; //Les agrega a los eventos su correspondiente listener
            skillButtons[i].SetSkillInfo(user.fightingCritters.Peek().MoveSet[i]); //cambia el texto
        }
    }


    public void RecycleButtons()
    {
        if (skillButtons.Count > 0)
        {
            for (int i = 0; i < skillButtons.Count; i++)
            {
                ButtonPool.Instance.Recycle(skillButtons[i]);
            }
            skillButtons = new List<SkillButton>();
        }
    }

    #endregion

    #region EnableAndDisable
    public void EnableButtons()
    {
        if(skillButtons.Count != 0)
        {
            ButtonHolder.gameObject.SetActive(true);
        }

    }
    public void DisableButtons()
    {
        ButtonHolder.gameObject.SetActive(false);
        
    }
    #endregion
    //Actualiza stats del critter con el que esta peleando en ese momento
    public void UpdateCurrentCritter(Critter critter)
    {
        hp.value = GetPercentage(critter.CurrentHp,critter.BaseHP);
        hptext.text = critter.CurrentHp.ToString() + " | " + critter.BaseHP.ToString();
        attack.text = "Attack : " + critter.Attack.ToString() + " | " + critter.BaseAttack.ToString();
        defense.text = "Defense : " + critter.Defense.ToString() + " | " + critter.BaseDefense.ToString();
        speed.text = "Speed : " + critter.Speed.ToString() + " | " + critter.BaseSpeed.ToString();


    }



    float GetPercentage(float currentV,float baseV)
    {
        return (float)(currentV / baseV) * 100;
    }
}
//void SetCritter(User player)
//{

//    for (int i = 0; i < player.critters.Count; i++)
//    {
//        critterImgs.Add(SpritePool.Instance.GetObject());
//        //
//        //Los hago hijo del buttonholder
//        critterImgs[i].GetComponent<RectTransform>().SetParent(SpritesHolder, false);

//        critterImgs[i].sprite = player.critters[i].img;
//    }



//}