using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReferee : MonoBehaviour, Icommand
{
    bool Winner = false;
    int Counter = 0;
    public Player[] players = new Player[2];

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

    }
    private void Start()
    {
        critters[0] = players[0].critters.Peek();//Player
        UIFacade.SET(players[0]);
        //critters[1] = players[1].critters.Peek();//EnemyBOT
    }
    public void Turn(int numberskill)
    {
        int index = Counter % 2;
        critters[index].MoveSet[numberskill].DoSkill(critters[index],critters[1-index]);
        if(critters[1 - index].Hp <= 0)
        {
            //Se lo agrego al ganador y se lo quito al perdedor
            players[index].critters.Enqueue(players[1-index].critters.Dequeue());
            //Se repone el del perdedor en caso de que todavia no haya un ganador
            if(players[1 - index].critters.Count == 0)
            {
                //En caso de no tener mas critters Pierde
                Winner = true;
            }
            else
            {
                //Sigue y se repone
                critters[1 - index] = players[1 - index].critters.Peek();
            }
        }
        Counter++;
        players[index].SetCommand(this);
        players[1 - index].eraseCommand();
    }

    public void Execute(int n)
    {
        Debug.Log("xdd");
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