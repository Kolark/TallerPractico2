using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class User : MonoBehaviour
{
    public List<CritterScriptableObject> critterScriptableObjects = new List<CritterScriptableObject>();

    public List<Critter> crittersInventory = new List<Critter>();
    public Queue<Critter> fightingCritters = new Queue<Critter>();
    Icommand commandToExecute;

    private void Awake()
    {
        for (int i = 0; i < critterScriptableObjects.Count; i++)
        {
            crittersInventory.Add(critterScriptableObjects[i].getObject());
        }
        //posible refactorAcá
        #region addfightingcritters
        if(crittersInventory.Count <= 3)
        {
            for (int i = 0; i < crittersInventory.Count; i++)
            {
                fightingCritters.Enqueue(crittersInventory[i]);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                fightingCritters.Enqueue(crittersInventory[i]);
            }
        }
        Debug.Log(" -- "  + fightingCritters.Count);
        #endregion
    }

    public virtual void SetCommand(Icommand command)
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
        if(commandToExecute != null)
        {
            commandToExecute.Execute(number);
        }
        else
        {
            Debug.Log("no command");
        }

    }
    #region AddandRemove
    public void AddCritter(Critter critter)
    {
        crittersInventory.Add(critter);
    }
    public void Remove(Critter critter)
    {
        crittersInventory.Remove(critter);
    }
    #endregion
}
