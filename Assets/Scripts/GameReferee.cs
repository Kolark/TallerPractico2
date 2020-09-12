using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameReferee : MonoBehaviour, Icommand
{
    bool Winner = false;
    int Counter = 0;
    public User[] players = new User[2];

    Critter[] critters = new Critter[2];

    private static GameReferee instance;
    public static GameReferee Instance { get => instance; }

    [SerializeField]
    UIFacade UIFacade;
    private void Awake()
    {
        #region singleton
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        #endregion
        //Obtener players y critters
        UIFacade.Init();

        
    }
    private void Start()
    {
        critters[0] = players[0].fightingCritters.Peek();//Player
        critters[1] = players[1].fightingCritters.Peek();//Bot
        UIFacade.UpdateUserUI(players[0], 0);
        UIFacade.UpdateUserUI(players[1], 1);
        UIFacade.EnableUserButtons(0);
        UIFacade.DisableUserButtons(1);
        PassCommand(Counter % 2);
        UIFacade.UpdateCrittersState(critters);
    }


    public void Execute(int numberskill)
    {
        int index = Counter % 2;
        UIFacade.EnableUserButtons(1-index);
        UIFacade.DisableUserButtons(index);
        critters[index].MoveSet[numberskill].DoSkill(critters[index],critters[1-index]);
        #region ifcritterdies

        if(critters[1 - index].CurrentHp <= 0)
        {
            //Se lo agrego al ganador y se lo quito al perdedor
            Critter critterLost = players[1 - index].fightingCritters.Dequeue();
            players[1 - index].Remove(critterLost);
            players[index].AddCritter(critterLost);      
            //Se repone el del perdedor en caso de que todavia no haya un ganador
            if(players[1 - index].fightingCritters.Count > 0)
            {
                critters[1 - index] = players[1 - index].fightingCritters.Peek();
                UIFacade.RecycleCritterSprite(1 - index);
                UIFacade.replenishCritter(1 - index);
                UIFacade.UpdateUserUI(players[1-index], 1-index);
            }
            else
            {
                Winner = true;
                SceneManager.LoadScene(1);
                return;
            }
            //Luego de esto se cambia los uis de los critters que tiene
            
            
        }
        #endregion
        Counter++;
        UIFacade.UpdateCrittersState(critters);
        PassCommand(1-index);

    }

    void PassCommand(int i)
    {
        players[i].SetCommand(this);
        players[1 - i].eraseCommand();
    }
}
