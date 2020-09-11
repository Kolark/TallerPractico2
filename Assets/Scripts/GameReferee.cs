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
            players[index].AddCritter(players[1 - index].fightingCritters.Dequeue());
            //Se repone el del perdedor en caso de que todavia no haya un ganador
            if(players[1 - index].fightingCritters.Count > 0)
            {
                //Sigue y se repone
                critters[1 - index] = players[1 - index].fightingCritters.Peek();
                //Reciclar y luego reponer
                //Actualiza los sprites
                UIFacade.RecycleCritterSprite(1 - index);
                UIFacade.replenishCritter(players[1 - index].fightingCritters.Peek(),1 - index);
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
//bool Winner = false;
//int Counter = 0;
//Player[] players = new Player[2];
//Stack<Critter>[] stacks = new Stack<Critter>[2];

//public Combat(Player player1, Player player2, List<Critter> crittersP1, List<Critter> crittersP2)
//{
//    players[0] = player1;
//    players[1] = player2;
//    stacks[0] = new Stack<Critter>(crittersP1);
//    stacks[1] = new Stack<Critter>(crittersP2);
//}

//public void Turn(int skill)
//{

//    if (!Winner)
//    {

//        int index = Counter % 2;
//        Console.WriteLine("The player  " + (index + 1) + " did the following effect");

//        if (skill < stacks[index].Peek().MoveSet.Count)
//        {
//            Console.WriteLine("critter: " + stacks[index].Peek().Name);
//            stacks[index].Peek().MoveSet[skill].DoSkill(stacks[index].Peek(), stacks[1 - index].Peek());
//            if (stacks[1 - index].Peek().Hp <= 0)
//            {
//                Critter exchange = stacks[1 - index].Pop();
//                players[index].critters.Add(exchange);
//                players[1 - index].critters.Remove(exchange);
//                Console.WriteLine("Fue vencido el critter del jugador " + ((1 - index) + 1));
//                if (players[1 - index].critters.Count == 0)
//                {
//                    Winner = true;
//                    Console.WriteLine("!!Hubo un ganador!!! y es el player : " + (index + 1));
//                }
//            }
//            Counter++;
//            index = Counter % 2;
//            Console.WriteLine("\nAhora es el turno del jugador: " + (index + 1));
//        }
//        else
//        {
//            Console.WriteLine("El skill con ese número no existe, número fuera de rango");
//        }

//    }
//}
//    }