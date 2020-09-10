using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Critter[] crittersToADD = new Critter[3];
    public Queue<Critter> critters = new Queue<Critter>();
    Icommand commandToExecute;

    
    private void Awake()
    {
        for (int i = 0; i < crittersToADD.Length; i++)
        {
            critters.Enqueue(crittersToADD[i]);
        }
    }

    public void SetCommand(Icommand command)
    {
        commandToExecute = command;
    }

    public void eraseCommand()
    {
        commandToExecute = null;
    }
    public void ExecuteComand(int number)
    {
        //Debe ser llamado desde los botones
        commandToExecute.Execute(number);
    }
}
