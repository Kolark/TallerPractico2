using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot : User
{
    public override void SetCommand(Icommand command)
    {
        base.SetCommand(command);
        StartCoroutine(waitandExecute());
        Debug.Log("Turno del bot");
    }
    IEnumerator waitandExecute ()
    {
        yield return new WaitForSeconds(2f);
        int command = Random.Range(0, base.fightingCritters.Peek().MoveSet.Count);
        base.ExecuteComand(command);
        Debug.Log("el bot ejecuto su comando");
    }
    
}
